
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

  public delegate void SpeckleEvent( object source, SpeckleEventArgs e );

  [Serializable]
  public partial class SpeckleApiClient : ISerializable
  {
    public bool UseGzip { get; set; } = true;
    public string BaseUrl { get; set; }
    public string AuthToken { get; set; }

    public string StreamId { get; set; }
    public string ClientId { get; set; }

    public User User { get; private set; }
    public SpeckleStream Stream { get; set; }

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

    Timer IsReady, WsReconnecter;

    //Default timeouts, pending further discussion
    private double defaultTimeoutMilliseconds = 3000;
    private double defaultBulkTimeoutMilliseconds = 60000;

    private Dictionary<string, SpeckleObject> ObjectCache = new Dictionary<string, SpeckleObject>();


    public SpeckleApiClient( string baseUrl, bool isPersistent = false )
    {
      SetSerialisationSettings();

      BaseUrl = baseUrl;
      IsPersistent = isPersistent;

      SetReadyTimer();
    }

    public SpeckleApiClient( bool useGzip = true )
    {
      SetSerialisationSettings();
      UseGzip = useGzip;
    }

    public SpeckleApiClient()
    {
      SetSerialisationSettings();
    }

    private void SetSerialisationSettings()
    {
      _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>( () =>
      {
        var settings = new Newtonsoft.Json.JsonSerializerSettings()
        {
          ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver() { NamingStrategy = new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy() },
          ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
          NullValueHandling = NullValueHandling.Ignore
        };
        UpdateJsonSerializerSettings( settings );
        return settings;
      } );
    }

    /// <summary>
    /// Initialises this client as a receiver for a specific stream. 
    /// </summary>
    /// <param name="streamId"></param>
    /// <param name="documentName"></param>
    /// <param name="documentType"></param>
    /// <param name="documentGuid"></param>
    /// <param name="authToken"></param>
    /// <returns></returns>
    public async Task IntializeReceiver( string streamId, string documentName, string documentType, string documentGuid, string authToken = null )
    {
      if( Role != null )
        throw new Exception( "Role changes are not permitted. Maybe create a new client?" );

      Role = ClientRole.Receiver;
      StreamId = streamId;

      try
      {
        AuthToken = authToken;
        User = (await this.UserGetAsync()).Resource;

      }
      catch( SpeckleException e )
      {
        OnError?.Invoke( this, new SpeckleEventArgs() { EventName = e.StatusCode.ToString(), EventData = e.Message } );
      }

      try
      {
        Stream = (await this.StreamGetAsync( streamId, null )).Resource;
        await SetupClient( documentName, documentType, documentGuid );
        SetupWebsocket();
      }
      catch( SpeckleException e )
      {
        OnError?.Invoke( this, new SpeckleEventArgs() { EventName = e.StatusCode.ToString(), EventData = e.Message } );
      }


    }
    /// <summary>
    /// Initialises this client as a Sender by creating a new stream.
    /// </summary>
    /// <param name="authToken"></param>
    /// <param name="documentName"></param>
    /// <param name="documentType"></param>
    /// <param name="documentGuid"></param>
    /// <returns></returns>
    public async Task<string> IntializeSender( string authToken, string documentName, string documentType, string documentGuid )
    {
      if( Role != null )
        throw new Exception( "Role changes are not permitted. Maybe create a new client?" );

      Role = ClientRole.Sender;

      try
      {
        AuthToken = authToken;
        User = (await this.UserGetAsync()).Resource;
      }
      catch( SpeckleException e )
      {
        OnError?.Invoke( this, new SpeckleEventArgs() { EventName = "error", EventData = "Could not log in: " + e.Message } );
        return null;
      }

      try
      {
        Stream = (await this.StreamCreateAsync( new SpeckleStream() )).Resource;
        StreamId = Stream.StreamId;

        await SetupClient( documentName, documentType, documentGuid );
        SetupWebsocket();

        return Stream.StreamId;
      }
      catch( SpeckleException e )
      {
        OnError?.Invoke( this, new SpeckleEventArgs() { EventName = e.StatusCode.ToString(), EventData = e.Message } );

        return null;
      }

    }

    private async Task SetupClient( string documentName = null, string documentType = null, string documentGuid = null )
    {
      if( ClientId == null )
      {
        LogEvent( "Creating a new client." );
        var myClient = new AppClient() { StreamId = StreamId, Role = Role.ToString(), Online = true, DocumentGuid = documentGuid, DocumentName = documentName, DocumentType = documentType };

        ClientId = (await this.ClientCreateAsync( myClient )).Resource._id;
      }
      else
      {
        LogEvent( "Setting client to alive." );
        await ClientUpdateAsync( ClientId, new AppClient() { Online = true } );
      }
    }

    private void LogEvent( string what )
    {
      OnLogData?.Invoke( this, new SpeckleEventArgs() { EventData = what } );
    }

    private void SetReadyTimer()
    {
      IsReady = new Timer( 200 ) { AutoReset = false, Enabled = true };
      IsReady.Elapsed += ( sender, e ) =>
      {
        LogEvent( "Checking readiness..." );
        if( StreamId == null || ClientId == null || WsConnected == false ) { IsReady.Start(); return; }
        OnReady?.Invoke( this, new SpeckleEventArgs() { EventName = "client-ready" } );
        IsConnected = true;
        LogEvent( "Client is ready!" );
      };
    }

    private void SetWsReconnectTimer()
    {
      WsReconnecter = new Timer( 1000 ) { AutoReset = false, Enabled = false };
      WsReconnecter.Elapsed += ( sender, e ) =>
      {
        if( IsDisposed ) return;
        WebsocketClient.Connect();
      };
    }

    /// <summary>
    /// Sets up the websocket client & its events..
    /// </summary>
    public void SetupWebsocket()
    {
      SetWsReconnectTimer();

      //generates a random guid
      if( ClientId == null )
        ClientId = Guid.NewGuid().ToString();

      WebsocketClient = new WebSocket( BaseUrl.Replace( "http", "ws" ) + "?access_token=" + AuthToken + "&stream_id=" + StreamId + "&client_id=" + ClientId );

      WebsocketClient.OnOpen += ( sender, e ) =>
      {
        WsConnected = true;
        WsReconnecter.Stop();
      };

      WebsocketClient.OnClose += ( sender, e ) =>
      {
        WsConnected = false;
        WsReconnecter.Start();
        OnError?.Invoke( this, new SpeckleEventArgs() { EventName = "websocket-disconnected" } );
      };

      WebsocketClient.OnMessage += ( sender, e ) =>
      {
        if( e.Data == "ping" ) { WebsocketClient.Send( "alive" ); LogEvent( "Got a ws ping." ); return; }

        LogEvent( "Got a ws message." );
        try
        {
          OnWsMessage?.Invoke( this, new SpeckleEventArgs() { EventName = "websocket-message", EventObject = JsonConvert.DeserializeObject<System.Dynamic.ExpandoObject>( e.Data ), EventData = e.Data } );
        }
        catch
        {
          OnWsMessage?.Invoke( this, new SpeckleEventArgs()
          {
            EventName = "websocket-message-unparsed",
            EventData = e.Data
          } );
        }
      };

      WebsocketClient.Connect();
    }

    /// <summary>
    /// Sends a direct message to another websocket client.
    /// </summary>
    /// <param name="receipientId">The clientId of the socket you want to send the message to.</param>
    /// <param name="args">What you want to send. Make it serialisable and small.</param>
    public void SendMessage( string receipientId, dynamic args )
    {
      if( !WsConnected )
      {
        OnError?.Invoke( this, new SpeckleEventArgs() { EventName = "Websocket client not connected.", EventData = "Websocket client not connected." } );
        return;
      }

      var eventData = new
      {
        eventName = "message",
        senderId = ClientId,
        recipientId = receipientId,
        streamId = StreamId,
        args = args
      };

      WebsocketClient.Send( JsonConvert.SerializeObject( eventData ) );
    }

    /// <summary>
    /// Broadcasts a message in a specific websocket room, as defined by resourceType and resourceId.
    /// </summary>
    /// <param name="resourceType">Can be stream, object, project, comment, user.</param>
    /// <param name="resourceId">The database id of the resource.</param>
    /// <param name="args">The message. Make it serialisable and small.</param>
    public void BroadcastMessage( string resourceType, string resourceId, dynamic args )
    {
      if( !WsConnected )
      {
        OnError?.Invoke( this, new SpeckleEventArgs() { EventName = "Websocket client not connected.", EventData = "Websocket client not connected." } );
        return;
      }

      var eventData = new
      {
        eventName = "broadcast",
        senderId = ClientId,
        resourceType = resourceType,
        resourceId = resourceId,
        args = args
      };

      WebsocketClient.Send( JsonConvert.SerializeObject( eventData ) );
    }

    /// <summary>
    /// Joins a websocket room based a resource type and its id. This will subscribe you to any broadcasts in that room.
    /// </summary>
    /// <param name="resourceType">Can be stream, object, project, comment, user.</param>
    /// <param name="resourceId">The database id of the resource.</param>
    public void JoinRoom( string resourceType, string resourceId )
    {
      if( !WsConnected )
      {
        OnError?.Invoke( this, new SpeckleEventArgs() { EventName = "Websocket client not connected.", EventData = "Websocket client not connected." } );
        return;
      }

      var eventData = new
      {
        eventName = "join",
        senderId = ClientId,
        resourceType = resourceType,
        resourceId = resourceId
      };

      WebsocketClient.Send( JsonConvert.SerializeObject( eventData ) );
    }

    /// <summary>
    /// Leaves a websocket room based a resource type and its id. This will stop you from receiving any broadcasts in that room.
    /// </summary>
    /// <param name="resourceType">Can be stream, object, project, comment, user.</param>
    /// <param name="resourceId">The database id of the resource.</param>
    public void LeaveRoom( string resourceType, string resourceId )
    {
      if( !WsConnected )
      {
        OnError?.Invoke( this, new SpeckleEventArgs() { EventName = "Websocket client not connected.", EventData = "Websocket client not connected." } );
        return;
      }

      var eventData = new
      {
        eventName = "leave",
        resourceType = resourceType,
        resourceId = resourceId
      };

      WebsocketClient.Send( JsonConvert.SerializeObject( eventData ) );
    }

    public void LogError( SpeckleException err )
    {
      OnError?.Invoke( this, new SpeckleEventArgs() { EventName = err.StatusCode.ToString(), EventData = err.Message, EventObject = err } );
    }

    protected SpeckleApiClient( SerializationInfo info, StreamingContext context )
    {
      _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>( () =>
       {
         var settings = new Newtonsoft.Json.JsonSerializerSettings()
         {
           ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver() { NamingStrategy = new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy() },
           ReferenceLoopHandling = ReferenceLoopHandling.Ignore
         };
         UpdateJsonSerializerSettings( settings );
         return settings;
       } );

      UseGzip = true;

      BaseUrl = info.GetString( "BaseUrl" );
      StreamId = info.GetString( "StreamId" );
      Role = (ClientRole) info.GetInt32( "Role" );
      ClientId = info.GetString( "ClientId" );

      //AuthToken = info.GetString( "ApiToken" );
      //string userEmail = null;

      // old clients will not have a user email field :/
      try
      {
        var userEmail = info.GetString( "UserEmail" );
        var acc = LocalContext.GetAccountByEmailAndRestApi( userEmail, BaseUrl );
        if( acc != null )
        {
          AuthToken = acc.Token;
          User = new User() { Email = acc.Email };
        }
        else
        {
          throw new Exception( "You do not have an account that matches this stream's server." );
        }
      }
      catch
      {
        var accs = LocalContext.GetAccountsByRestApi( BaseUrl );
        var sorted = accs.OrderByDescending( acc => acc.IsDefault ).ToList();
        if( sorted.Count == 0 )
        {
          throw new Exception( "You do not have an account that matches this stream's server." );
        }
        else
        {
          AuthToken = accs[ 0 ].Token;
          User = new User() { Email = sorted[ 0 ].Email };
        }
      }

      Stream = StreamGetAsync( StreamId, null ).Result.Resource;

      // does not need waiting for, as we already have a clientid.
      SetupClient();
      SetupWebsocket();

      SetReadyTimer();
      SetWsReconnectTimer();
    }

    public void GetObjectData( SerializationInfo info, StreamingContext context )
    {
      info.AddValue( "UserEmail", User?.Email );
      info.AddValue( "BaseUrl", BaseUrl );
      info.AddValue( "StreamId", StreamId );
      info.AddValue( "Role", Role );
      info.AddValue( "ClientId", ClientId );

      //info.AddValue( "ApiToken", AuthToken );
    }

    public void Dispose( bool delete = false )
    {
      IsDisposed = true;

      if( !delete )
      {
        ClientUpdateAsync( ClientId, new AppClient() { Online = false } );
        WebsocketClient?.Close();
        return;
      }
      ClientDeleteAsync( ClientId );
      WebsocketClient?.Close();
    }
  }
}
