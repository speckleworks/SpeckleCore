using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WebSocketSharp;

namespace SpeckleCore
{
    [Serializable]
    public enum ClientRole { Sender, Receiver, Mixed };

    public class SpeckleEventArgs : EventArgs
    {
        public string EventName { get; set; }
        public string EventData { get; set; }
        public dynamic EventObject { get; set; }
    }

    public delegate void SpeckleEvent(object source, SpeckleEventArgs e);

    [Serializable]
    public partial class SpeckleApiClient : BaseSpeckleApiClient, ISerializable
    {
        public string StreamId { get; private set; }
        public string ClientId { get; private set; }

        public User User { get; private set; }
        public DataStream Stream { get; private set; }

        public ClientRole? Role { get; private set; } = null;

        public bool IsAuthorized { get; private set; } = false;
        public bool IsPersistent { get; private set; } = false;

        WebSocket WebsocketClient;
        public bool WsConnected { get; private set; } = false;
        public bool IsDisposed { get; private set; } = false;
        public bool IsConnected { get; private set; } = false;

        public event SpeckleEvent OnError;
        public event SpeckleEvent OnReady;
        public event SpeckleEvent OnWsMessage;

        public event SpeckleEvent OnLogData;

        public Converter Converter { get; set; }

        Timer IsReady, WsReconnecter;
        Timer MetadataSender, DataSender;

        // buckets
        private string BucketName;
        private List<SpeckleLayer> BucketLayers = new List<SpeckleLayer>();
        private List<object> BucketObjects = new List<object>();
        private List<SpeckleObject> SpeckleBucketObjects = new List<SpeckleObject>();

        private Dictionary<string, SpeckleObject> SentObjects = new Dictionary<string, SpeckleObject>();


        public SpeckleApiClient(string baseUrl, Converter converter, bool isPersistent = false) : base()
        {
            BaseUrl = baseUrl;
            IsPersistent = isPersistent;
            Converter = converter;

            SetReadyTimer();
            SetTimers();
        }

        public async Task IntializeReceiver(string streamId, string authToken = null)
        {
            if (Role != null)
                throw new Exception("Role changes are not permitted. Maybe create a new client?");

            Role = ClientRole.Receiver;
            StreamId = streamId;

            try
            {
                AuthToken = authToken;
                User = (await this.UserGetProfileAsync()).User;

            }
            catch
            {
                throw new Exception("Login error. Auth token is invalid.");
            }

            try
            {
                await SetupClient();
                SetupWebsocket();
            }
            catch { throw new Exception("Could not get stream."); }


        }

        public async Task IntializeReceiver(string streamId, string email = null, string password = null)
        {
            if (Role != null)
                throw new Exception("Role changes are not permitted. Maybe create a new client?");

            Role = ClientRole.Receiver;
            StreamId = streamId;

            try
            {
                var payload = new PayloadAccountLogin() { Email = email, Password = password };
                AuthToken = (await this.UserLoginAsync(payload)).ApiToken;
                User = (await this.UserGetProfileAsync()).User;
            }
            catch
            {
                throw new Exception("Login error. Credentials incorrect.");
            }

            try
            {
                Stream = (await this.StreamGetAsync(streamId)).Stream;
                var x = Stream;
            }
            catch { throw new Exception("Could not get stream."); }
        }

        public async Task<string> IntializeSender(string authToken)
        {
            if (Role != null)
                throw new Exception("Role changes are not permitted. Maybe create a new client?");

            Role = ClientRole.Sender;

            try
            {
                AuthToken = authToken;
                User = (await this.UserGetProfileAsync()).User;
            }
            catch
            {
                throw new Exception("Login error. Auth token is invalid.");
            }

            try
            {
                Stream = (await this.StreamCreateAsync()).Stream;
                StreamId = Stream.StreamId;

                await SetupClient();
                SetupWebsocket();

                return Stream.StreamId;
            }
            catch
            {
                throw new Exception("Failed to create a new stream.");
            }

        }

        public async Task<string> IntializeSender(string email, string password)
        {
            if (Role != null)
                throw new Exception("Role changes are not permitted. Maybe create a new client?");

            Role = ClientRole.Sender;

            try
            {
                var payload = new PayloadAccountLogin() { Email = email, Password = password };
                AuthToken = (await this.UserLoginAsync(payload)).ApiToken;
                User = (await this.UserGetProfileAsync()).User;
            }
            catch
            {
                throw new Exception("Login error. Credentials incorrect.");
            }

            try
            {
                Stream = (await this.StreamCreateAsync()).Stream;
                StreamId = Stream.StreamId;
                LogEvent("Created a new stream.");
                await SetupClient();
                SetupWebsocket();

                return Stream.StreamId;
            }
            catch
            {
                throw new Exception("Failed to create a new stream.");
            }
        }

        private async Task SetupClient()
        {
            if (ClientId == null)
            {
                LogEvent("Creating a new client.");
                var payload = new PayloadClientCreate() { Client = new SpeckleClient() { StreamId = StreamId, Role = Role.ToString(), Online = true } };
                ClientId = (await this.ClientCreateAsync(payload)).ClientId;
            }
            else
            {
                LogEvent("Setting client to alive.");
                var payload = new PayloadClientUpdate() { Client = new SpeckleClient() { Online = true } };
                this.ClientUpdate(payload, ClientId);
            }
        }

        private void LogEvent(string what)
        {
            OnLogData?.Invoke(this, new SpeckleEventArgs() { EventData = what });
        }

        private void SetReadyTimer()
        {
            IsReady = new Timer(200) { AutoReset = false, Enabled = true };
            IsReady.Elapsed += (sender, e) =>
            {
                LogEvent("Checking readiness...");
                if (StreamId == null || ClientId == null || WsConnected == false) { IsReady.Start(); return; }
                OnReady?.Invoke(this, new SpeckleEventArgs() { EventName = "client-ready" });
                IsConnected = true;
                LogEvent("Client is reay!");
            };
        }

        private void SetWsReconnectTimer()
        {
            WsReconnecter = new Timer(1000) { AutoReset = false, Enabled = false };
            WsReconnecter.Elapsed += (sender, e) =>
            {
                if (IsDisposed) return;
                WebsocketClient.Connect();
            };
        }

        private void SetTimers()
        {
            MetadataSender = new Timer(1000) { AutoReset = false, Enabled = false };
            MetadataSender.Elapsed += MetadataSender_Elapsed;

            DataSender = new Timer(2000) { AutoReset = false, Enabled = false };
            DataSender.Elapsed += DataSender_Elapsed;
        }


        public void UpdateMetadataDebounced(string name, IEnumerable<SpeckleLayer> layers)
        {
            BucketLayers = layers.ToList();
            BucketName = name;

            MetadataSender.Start();
            Dictionary<string, ISerializable> what;

        }

        private void MetadataSender_Elapsed(object sender, ElapsedEventArgs e)
        {
            var payload = new PayloadStreamMetaUpdate();
            payload.Layers = BucketLayers;
            payload.Name = BucketName;

            StreamUpdateMetaAsync(payload, StreamId).ContinueWith(task =>
            {
                LogEvent("Metadata updated.");
                BroadcastMessage(new { eventType = "update-meta" });
            });
        }


        public void UpdateDataDebonuced(string name, IEnumerable<object> objects, IEnumerable<SpeckleLayer> layers)
        {
            BucketObjects = objects.ToList();
            BucketLayers = layers.ToList();
            BucketName = name;

            LogEvent("Data update intialised.");

            DataSender.Start();
        }

        private void DataSender_Elapsed(object sender, ElapsedEventArgs e)
        {
            LogEvent("Sending data update.");

            PayloadStreamUpdate payload = new PayloadStreamUpdate();

            payload.Layers = BucketLayers;
            payload.Name = BucketName;
            SpeckleObject[] payloadObjList = new SpeckleObject[BucketObjects.Count];

            var convertedObjects = Converter.ToSpeckle(BucketObjects);

            int index = 0, insertedCount = 0;
            foreach (SpeckleObject newGuy in convertedObjects)
            {
                if (SentObjects.ContainsKey(newGuy.Hash))
                {
                    LogEvent(String.Format("Object {0} out of {1} done (cached).", index, BucketObjects.Count));
                    payloadObjList[index] = SentObjects[newGuy.Hash];
                    insertedCount++;
                    if (insertedCount == BucketObjects.Count)
                    {
                        payload.Objects = payloadObjList;
                        StreamUpdateAsync(payload, StreamId).ContinueWith(task =>
                        {
                            LogEvent("Data updated.");
                            BroadcastMessage(new { eventType = "update-global" });
                        });
                    }
                }
                else
                {
                    int indexCopy = index;
                    ObjectCreateAsync(new PayloadCreateObject() { Object = newGuy }).ContinueWith(tres =>
                    {
                        var placeholder = new SpeckleObject() { DatabaseId = tres.Result.ObjectId, Type = newGuy.Type, Hash = newGuy.Hash };
                        LogEvent(String.Format("Object {0} out of {1} done (created).", indexCopy, BucketObjects.Count));
                        SentObjects[placeholder.Hash] = placeholder;
                        payloadObjList[indexCopy] = placeholder;
                        insertedCount++;
                        if (insertedCount == BucketObjects.Count)
                        {
                            payload.Objects = payloadObjList;
                            StreamUpdateAsync(payload, StreamId).ContinueWith(task =>
                            {
                                LogEvent("Data updated.");
                                BroadcastMessage(new { eventType = "update-global" });
                            });
                        }
                    });
                }
                index++;
            }

        }

        public void GetObjectList(IEnumerable<SpeckleObjectPlaceholder> objects, Action<List<SpeckleObject>> callback)
        {
            SpeckleObject[] speckleObjectList = new SpeckleObject[objects.Count()];
            int index = 0, insertedCount = 0;

            foreach (var newGuy in objects)
            {
                if (SentObjects.ContainsKey(newGuy.Hash))
                {
                    speckleObjectList[index] = SentObjects[newGuy.Hash];
                    insertedCount++;
                    if (insertedCount == objects.Count())
                    {
                        callback(speckleObjectList.ToList());
                    }
                }
                else
                {
                    int indexCopy = index;
                    ObjectGetAsync(newGuy.DatabaseId).ContinueWith(tres =>
                    {
                        speckleObjectList[indexCopy] = tres.Result.SpeckleObject;
                        SentObjects[newGuy.Hash] = tres.Result.SpeckleObject;
                        insertedCount++;
                        if (insertedCount == objects.Count())
                        {
                            callback(speckleObjectList.ToList());
                        }
                    });
                }
                index++;
            }
        }

        private void SetupWebsocket()
        {
            SetWsReconnectTimer();

            WebsocketClient = new WebSocket(BaseUrl.Replace("http", "ws") + "?access_token=" + AuthToken + "&stream_id=" + StreamId + "&client_id=" + ClientId);

            WebsocketClient.OnOpen += (sender, e) =>
            {
                WsConnected = true;
                WsReconnecter.Stop();
            };

            WebsocketClient.OnClose += (sender, e) =>
            {
                WsConnected = false;
                WsReconnecter.Start();
                OnError?.Invoke(this, new SpeckleEventArgs() { EventName = "websocket-disconnected" });
            };

            WebsocketClient.OnMessage += (sender, e) =>
            {
                if (e.Data == "ping") { WebsocketClient.Send("alive"); LogEvent("Got a ws ping."); return; }

                LogEvent("Got a ws message.");

                OnWsMessage?.Invoke(this, new SpeckleEventArgs() { EventName = "websocket-message", EventObject = JsonConvert.DeserializeObject<System.Dynamic.ExpandoObject>(e.Data), EventData = e.Data });
            };

            WebsocketClient.Connect();
        }

        public void SendMessage(string receipientId, dynamic args)
        {
            var eventData = new
            {
                eventName = "message",
                senderId = ClientId,
                recipientId = receipientId,
                streamId = StreamId,
                args = args
            };

            WebsocketClient.Send(JsonConvert.SerializeObject(eventData));
        }

        public void BroadcastMessage(dynamic args)
        {
            var eventData = new
            {
                eventName = "broadcast",
                senderId = ClientId,
                streamId = StreamId,
                args = args
            };

            WebsocketClient.Send(JsonConvert.SerializeObject(eventData));
        }

        protected SpeckleApiClient(SerializationInfo info, StreamingContext context)
        {
            BaseUrl = info.GetString("BaseUrl");
            StreamId = info.GetString("StreamId");
            Role = (ClientRole)info.GetInt32("Role");
            AuthToken = info.GetString("ApiToken");
            ClientId = info.GetString("ClientId");

            // does not need waiting for, as we already have a clientid.
            SetupClient();
            SetupWebsocket();

            SetTimers();
            SetReadyTimer();
            SetWsReconnectTimer();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BaseUrl", BaseUrl);
            info.AddValue("StreamId", StreamId);
            info.AddValue("Role", Role);
            info.AddValue("ApiToken", AuthToken);
            info.AddValue("ClientId", ClientId);
        }

        public void Dispose()
        {
            IsDisposed = true;
            var payload = new PayloadClientUpdate() { Client = new SpeckleClient() { Online = false } };
            try { ClientUpdateAsync(payload, ClientId); } catch { }
            try { WebsocketClient.Close(); } catch { }
        }
    }

    public class SpeckleCache
    {
        HashSet<string> HashSet { get; set; }
    }
}
