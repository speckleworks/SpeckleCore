using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CountlySDK;
using CountlySDK.Entities;
using DeviceId;
using DeviceId.Encoders;
using DeviceId.Formatters;

namespace SpeckleCore
{
  public static class SpeckleTelemetry
  {
    private static bool isInitialized = false;

    public static string DeviceId { get; set; }

    public static void Initialize( )
    {
      if ( isInitialized )
        return;

      if ( LocalContext.GetTelemetrySettings() == false )
        return;
      try
      {
        DeviceId = new DeviceIdBuilder()
          .AddMachineName()
          .AddProcessorId()
          .UseFormatter(new HashDeviceIdFormatter(() => SHA256.Create(), new Base64UrlByteArrayEncoder()))
          .ToString();

        var config = new CountlyConfig()
        {
          serverUrl = "https://telemetry.speckle.works",
          appKey = "cd6db5058036aafb6a3a82681d434ad74ee50ad9",
          deviceIdMethod = Countly.DeviceIdMethod.developerSupplied,
          developerProvidedDeviceId = DeviceId
        };

        Countly.IsLoggingEnabled = true;
        Countly.Instance.Init(config);
        Countly.Instance.RecordView("speckle-init");
        Countly.Instance.RecordView("speckle-init/version/" + typeof(SpeckleTelemetry).Assembly.GetName().Version);

        isInitialized = true;
      }catch(Exception e)
      {
        // POKEMON
        isInitialized = false;
      }
    }

    public static void RecordTestEvent( string clientType )
    {
      Initialize();

      if ( LocalContext.GetTelemetrySettings() == false )
        return;

      var segmentation = GetSegmentation( clientType );
      var test = Countly.RecordEvent( "test-event", 1, segmentation ).Result;
    }

    public static void RecordStreamCreated( string clientType )
    {
      Initialize();

      if ( LocalContext.GetTelemetrySettings() == false )
        return;

      Task.Run( ( ) =>
      {
        try
        {
          Countly.RecordEvent( "stream-created", 1, GetSegmentation( clientType ) );
        }
        catch ( Exception e )
        {
        }
      } );
    }

    public static void RecordStreamUpdated( string clientType )
    {
      Initialize();

      if ( LocalContext.GetTelemetrySettings() == false )
        return;

      Task.Run( ( ) =>
      {
        try
        {
          Countly.RecordEvent( "stream-updated", 1, GetSegmentation( clientType ) );
        }
        catch { }
      } );
    }

    public static void RecordStreamReceived( string clientType )
    {
      Initialize();

      if ( LocalContext.GetTelemetrySettings() == false )
        return;

      Task.Run( ( ) =>
      {
        try
        {
          Countly.RecordEvent( "stream-received", 1, GetSegmentation( clientType ) );
        }
        catch ( Exception e )
        {

        }
      } );
    }

    private static Segmentation GetSegmentation( string clientType = "undefined" )
    {
      Initialize();
      var segmentation = new Segmentation();
      segmentation.Add( "machineId", DeviceId );
      segmentation.Add( "clientType", clientType );
      segmentation.Add( "coreVersion", GetAssemblyVersion() );
      return segmentation;
    }

    private static string GetAssemblyVersion( )
    {
      return System.Reflection.Assembly.GetCallingAssembly().GetName().Version.ToString();
    }
  }
}
