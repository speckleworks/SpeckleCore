using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SpeckleCore
{
  /// <summary>
  /// Thanks to @radugidei for the idea: we're attempting to rip off NancyFX's guerilla assembly loading.
  /// See original src (MIT): 
  /// https://raw.githubusercontent.com/NancyFx/Nancy/de458a9b42db6478e0c2bb8adef0f9fa342a2674/src/Nancy/AppDomainAssemblyCatalog.cs
  /// </summary>
  public class SpeckleKitLoader
  {
    private readonly AssemblyName SpeckleAssemblyName;
    private readonly Lazy<IReadOnlyCollection<Assembly>> assemblies;

    public string SpeckleKitsDirectory;

    public SpeckleKitLoader( )
    {

#if !DEBUG
      SpeckleKitsDirectory = System.Environment.GetFolderPath( System.Environment.SpecialFolder.LocalApplicationData ) + @"\SpeckleKitsDebug\";
#else
      SpeckleKitsDirectory = System.Environment.GetFolderPath( System.Environment.SpecialFolder.LocalApplicationData ) + @"\SpeckleKits\";
#endif

      SpeckleAssemblyName = typeof( SpeckleObject ).GetTypeInfo().Assembly.GetName();
      assemblies = new Lazy<IReadOnlyCollection<Assembly>>( GetAvailableAssemblies );
    }

    public virtual IReadOnlyCollection<Assembly> GetAssemblies( )
    {
      return this.assemblies.Value;
    }

    private IReadOnlyCollection<Assembly> GetAvailableAssemblies( )
    {
      var assemblies = GetLoadedSpeckleReferencingAssemblies();

      var loaded = LoadSpeckleReferencingAssemblies( assemblies );

      return assemblies.Union( loaded ).ToArray();
    }

    private List<Assembly> GetLoadedSpeckleReferencingAssemblies( )
    {
      var assemblies = new List<Assembly>();

      foreach ( var assembly in AppDomain.CurrentDomain.GetAssemblies() )
      {
        if ( !assembly.IsDynamic && !assembly.ReflectionOnly && assembly.IsReferencing( SpeckleAssemblyName ) )
        {
          assemblies.Add( assembly );
        }
      }

      return assemblies;
    }

    private IEnumerable<Assembly> LoadSpeckleReferencingAssemblies( IEnumerable<Assembly> loadedAssemblies )
    {
      var assemblies = new HashSet<Assembly>();
      var loadedSpeckleReferencingAssemblyNames = loadedAssemblies.Select( assembly => assembly.GetName() ).ToArray();
      var directories = Directory.GetDirectories( SpeckleKitsDirectory );
      var currDomain = AppDomain.CurrentDomain;


      foreach ( var directory in directories )
      {
        foreach ( var assemblyPath in System.IO.Directory.EnumerateFiles( directory, "*.dll" ) )
        {
          var unloadedAssemblyName = SafeGetAssemblyName( assemblyPath );

          if ( unloadedAssemblyName == null )
          {
            continue;
          }

          if ( !loadedSpeckleReferencingAssemblyNames.Any( loadedSpeckleReferencingAssemblyName => AssemblyName.ReferenceMatchesDefinition( loadedSpeckleReferencingAssemblyName, unloadedAssemblyName ) ) )
          {
            var relfectionLoadAssembly = Assembly.ReflectionOnlyLoadFrom( assemblyPath );
            var isReferencingCore = relfectionLoadAssembly.IsReferencing( SpeckleAssemblyName );

            if ( isReferencingCore )
            {
              Debug.WriteLine( "Load converter: " + unloadedAssemblyName );
              var assembly = SafeLoadAssembly( AppDomain.CurrentDomain, unloadedAssemblyName );
              if ( assembly != null )
              {
                var res = assembly.GetTypes();
                var copy = res;

                assemblies.Add( assembly );
              }
            }
          }
        }
      }
      return assemblies.ToArray();
    }

    private static AssemblyName SafeGetAssemblyName( string assemblyPath )
    {
      try
      {
        return AssemblyName.GetAssemblyName( assemblyPath );
      }
      catch
      {
        return null;
      }
    }

    private static Assembly SafeLoadAssembly( AppDomain domain, AssemblyName assemblyName )
    {
      try
      {
        return domain.Load( assemblyName );
      }
      catch
      {
        return null;
      }
    }
  }

  public static class AssemblyExtensions
  {
    /// <summary>
    /// Indicates if a given assembly references another which is identified by its name.
    /// </summary>
    /// <param name="assembly">The assembly which will be probed.</param>
    /// <param name="referenceName">The reference assembly name.</param>
    /// <returns>A boolean value indicating if there is a reference.</returns>
    public static bool IsReferencing( this Assembly assembly, AssemblyName referenceName )
    {
      if ( AssemblyName.ReferenceMatchesDefinition( assembly.GetName(), referenceName ) )
      {
        return true;
      }

      foreach ( var referencedAssemblyName in assembly.GetReferencedAssemblies() )
      {
        if ( AssemblyName.ReferenceMatchesDefinition( referencedAssemblyName, referenceName ) )
        {
          return true;
        }
      }

      return false;
    }

  }
}
