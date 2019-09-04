using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CountlySDK;
using CountlySDK.Entities;
using DeviceId;
using DeviceId.Encoders;
using DeviceId.Formatters;

namespace SpeckleCore
{
  /// <summary>
  /// Use this interface to make sure static extension methods/object defintions are loaded from SpeckleKits AND/OR that you force a reference to SpeckleCore (thus making sure the assembly is loaded.
  /// </summary>
  public interface ISpeckleInitializer { }

  /// <summary>
  /// Initialisation class to be called from any application that hosts the speckle plugin
  /// at the begginning of the rituals
  /// </summary>
  public static class SpeckleInitializer
  {
    private static bool IsInit = false;
    private static IReadOnlyCollection<Assembly> Assembiles;
    private static IReadOnlyCollection<Type> Types;

    public static void Initialize( )
    {
      if ( IsInit ) return;

      IsInit = true;

      LocalContext.Init();
      Assembiles = new SpeckleKitLoader().GetAssemblies();

      var types = new List<Type>();
      foreach ( var assembly in Assembiles )
      {
        types.AddRange( FindDerivedTypes( assembly, typeof( SpeckleObject ) ).ToList() );
      }
      types.Add( typeof( SpeckleObject ) );
      Types = types;
    }

    /// <summary>
    /// Returns all the assemblies that have been loaded and are referencing SpeckleCore. 
    /// </summary>
    /// <returns></returns>
    public static IReadOnlyCollection<Assembly> GetAssemblies( )
    {
      return Assembiles;
    }

    /// <summary>
    /// Gets the available speckle types, from core and other speckle kits.
    /// </summary>
    /// <returns></returns>
    public static IReadOnlyCollection<Type> GetTypes( )
    {
      return Types;
    }

    private static IEnumerable<Type> FindDerivedTypes( Assembly assembly, Type baseType )
    {
      var types = assembly.GetTypes();
      return assembly.GetTypes().Where( t => t.IsSubclassOf( baseType ) );
    }
  }

  public static class SpeckleTelemetry
  {
    private static bool isInitialized = false;

    public static string DeviceId { get; set; }

    public static void Initialize( )
    {
      if ( isInitialized )
        return;

      DeviceId = new DeviceIdBuilder()
        .AddMachineName()
        .AddProcessorId()
        .UseFormatter( new HashDeviceIdFormatter( ( ) => SHA256.Create(), new Base64UrlByteArrayEncoder() ) )
        .ToString();

      var config = new CountlyConfig()
      {
        serverUrl = "https://telemetry.speckle.works",
        appKey = "cd6db5058036aafb6a3a82681d434ad74ee50ad9",
        deviceIdMethod = Countly.DeviceIdMethod.developerSupplied,
        developerProvidedDeviceId = DeviceId
      };
      Countly.IsLoggingEnabled = true;
      Countly.Instance.Init( config );
      Countly.Instance.RecordView( "speckle-init" );
      Countly.Instance.RecordView( "speckle-init/version/" + typeof( SpeckleTelemetry ).Assembly.GetName().Version );

      isInitialized = true;
    }

    public static void RecordTestEvent( string clientType )
    {
      Initialize();
      var segmentation = GetSegmentation( clientType );
      var test = Countly.RecordEvent( "test-event", 1, segmentation ).Result;
    }

    public static void RecordStreamCreated( string clientType )
    {
      Initialize();
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

    private static Segmentation GetSegmentation( string clientType )
    {
      Initialize();
      var segmentation = new Segmentation();
      segmentation.Add( "machineId", DeviceId );
      segmentation.Add( "clientType", clientType );
      segmentation.Add( "coreVersion", GetAssemblyVersion() );
      return segmentation;
    }

    private static string GetClientType( )
    {
      return System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
    }

    private static string GetAssemblyVersion( )
    {
      return System.Reflection.Assembly.GetCallingAssembly().GetName().Version.ToString();
    }
  }
}
