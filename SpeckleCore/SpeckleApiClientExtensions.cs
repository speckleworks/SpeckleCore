using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WebSocketSharp;

namespace SpeckleCore
{
    [Serializable]
    public enum ClientRole { Sender, Receiver, Mixed }

    [Serializable]
    public abstract class SpeckleCoreClient
    {
        public string ClientId { get; set; }
        public string StreamId { get; set; }
        public string BaseUrl { get; set; }

        public ClientRole Role { get; set; }

        public SpeckleCoreRestClient RestClient = new SpeckleCoreRestClient();

        public WebSocket WebSocket;

        public event SpeckleEvent OnInitReady, OnError, OnDataSent;

        public event SpeckleEvent OnCustomMessage;

        public SpeckleCoreClient(string _BaseUrl, ClientRole _Role)
        {
            RestClient.BaseUrl = _BaseUrl;
            BaseUrl = _BaseUrl;
            Role = _Role;
        }

        public void UpdateStream(IEnumerable<SpeckleObject> objects, IEnumerable<SpeckleLayer> layers, string name)
        {

        }

        #region layers update methods
        public void UpdateStreamLayers(IEnumerable<SpeckleLayer> layers)
        {

        }

        public void AddLayer(SpeckleLayer layer)
        {

        }

        public void AddLayers(IEnumerable<SpeckleLayer> layers)
        {

        }

        public void RemoveLayer(SpeckleLayer layer)
        {

        }

        public void RemoveLayers(IEnumerable<SpeckleLayer> layers)
        {

        }
        #endregion

        public void UpdateStreamName(string name)
        {

        }

        public void UpdateStreamObjects()
        {

        }
    }

    public class SpeckleEventArgs : EventArgs
    {
        public string EventInfo { get; set; }
        public string EventData { get; set; }
    }
    public delegate void SpeckleEvent(object source, SpeckleEventArgs e);

    //[Serializable]
    //public partial class SpeckleApiClient : ISerializable
    //{
    //    public string ApiToken { get; set; }
    //    public string StreamId { get; set; }
    //    public string ClientId { get; set; }

    //    public ClientRole Role { get; set; }

    //    WebSocket WSocket;

    //    Timer IsReadyChecker, WSocketReconnecter;

    //    bool WsConnected = false, AuthValid = false, StreamValid = false;

    //    List<SpeckleObject> objects;
    //    List<SpeckleLayer> layers;
    //    string name;

    //    public SpeckleApiClient(string _BaseUrl, string _StreamId, ClientRole _Role)
    //    {
    //        BaseUrl = _BaseUrl; StreamId = _StreamId; Role = _Role;
    //    }

    //    public SpeckleApiClient(string _BaseUrl, string _StreamId, string Email, string Password)
    //    {

    //    }

    //    #region Serialisation: Constructor and Serializer
    //    // deserialise
    //    protected SpeckleApiClient(SerializationInfo info, StreamingContext context)
    //    {
    //        BaseUrl = info.GetString("BaseUrl");
    //        StreamId = info.GetString("StreamId");
    //        Role = (ClientRole)info.GetInt32("Role");
    //        ApiToken = info.GetString("ApiToken");
    //        ClientId = info.GetString("ClientId");
    //    }

    //    // serialise
    //    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("BaseUrl", BaseUrl);
    //        info.AddValue("StreamId", StreamId);
    //        info.AddValue("Role", Role);
    //        info.AddValue("ApiToken", ApiToken);
    //        info.AddValue("ClientId", ClientId);
    //    }
    //    #endregion

    //    public void WebsocketSetup()
    //    {
    //        WSocket = new WebSocket(BaseUrl + "?access_token=" + ApiToken + "&stream_id=" + StreamId + "&client_id=" + ClientId);

    //        WSocket.OnOpen += (sender, e) =>
    //        {
    //            WsConnected = true;
    //            WSocketReconnecter.Stop();
    //        };

    //        WSocket.OnClose += (sender, e) =>
    //        {
    //            WsConnected = false;
    //            WSocketReconnecter.Start();
    //        };

    //        WSocket.OnMessage += (sender, e) =>
    //        {
    //            Debug.WriteLine($"SpeckleApiClient[{BaseUrl}, { StreamId}, {Role}] received websocket message: {e.RawData}");

    //            if (e.Data == "ping") { WSocket.Send("alive"); return; }
    //            if (Role == ClientRole.Sender) return;

    //            var message = JsonConvert.DeserializeObject<dynamic>(e.Data);
    //            // TODO: Message handler
    //        };
    //    }

    //    public void RestSetup()
    //    {
    //        this.UserGetProfileAsync(ApiToken).ContinueWith(TaskResult =>
    //        {
    //            if (TaskResult.Result.Success) this.AuthValid = true;

    //        });

    //        this.StreamGetAsync(StreamId, ApiToken).ContinueWith(TaskResult =>
    //        {
    //            if (TaskResult.Result.Success) this.StreamValid = true;
    //            else throw new Exception($"Could not get stream {StreamId}.");
    //        });
    //    }

    //    public void TimerSetup()
    //    {
    //        IsReadyChecker = new Timer(200) { AutoReset = false, Enabled = true };
    //        IsReadyChecker.Elapsed += (sender, e) =>
    //        {
    //            if (!StreamValid) { IsReadyChecker.Start(); return; }
    //            if (!WsConnected) { IsReadyChecker.Start(); return; }
    //        };

    //        WSocketReconnecter = new Timer(1000) { AutoReset = false, Enabled = false };
    //        WSocketReconnecter.Elapsed += (sender, e) => { WSocket.Connect(); };
    //    }

    //    public void BroadcastMessage(SpeckleSocketMessage message)
    //    {
    //        WSocket.SendAsync(message.Message, completed =>
    //        {
    //            Debug.WriteLine($"SpeckleApiClient [{BaseUrl}, {StreamId},{Role}] broadcasted {message.EventName}. Success: {completed}");
    //            if (!completed) throw new Exception($"SpeckleApiClient [{BaseUrl}, {StreamId},{Role}] failed to broadcast message");
    //        });
    //    }
    //}
}
