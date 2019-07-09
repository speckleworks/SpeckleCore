using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
}
