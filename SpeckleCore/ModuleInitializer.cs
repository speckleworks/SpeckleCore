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

    public static void Initialize(bool useLocalContext = true, bool kitsAlreadyLoaded = false, string pathToKits = null)
    {
      if ( IsInit ) return;

      IsInit = true;

      if (useLocalContext) LocalContext.Init();

      Assembiles = new SpeckleKitLoader(kitsAlreadyLoaded, pathToKits).GetAssemblies();

      var types = new List<Type>();
      foreach ( var assembly in Assembiles )
      {
        types.AddRange( FindDerivedTypes( assembly, typeof( SpeckleObject ) ).ToList() );
      }
      types.Add( typeof( SpeckleObject ) );
      Types = types;

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///                                                                                              ///
            ///                                                                                              ///
            /// Hello devs! Uncomment the line below to disable telemetry.                                   ///
            /// This will make speckle sad, but it's your call.                                              ///
            /// See community discussions here:                                                              ///
            /// https://speckle-works.slack.com/archives/C4TE17LGH/p1567520201017900                         ///
            /// https://discourse.speckle.works/t/community-consultation-time-telemetry/410                  ///
            ///                                                                                              ///
            ///                                                                                              ///
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            // LocalContext.SetTelemetrySettings( false );

            // Note: if telemetry settings is set to false, then this will do nothing.
            if (useLocalContext) SpeckleTelemetry.Initialize();
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

}
