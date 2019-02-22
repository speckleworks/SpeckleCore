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
  /// Thanks to @radugidei for the idea. 
  /// Here we're attempting to rip off Speckle's guerilla assembly loading.
  /// Original src: https://raw.githubusercontent.com/NancyFx/Nancy/de458a9b42db6478e0c2bb8adef0f9fa342a2674/src/Nancy/AppDomainAssemblyCatalog.cs
  /// </summary>
  public class ConverterLoader
  {
    private static readonly AssemblyName SpeckleAssemblyName = typeof( SpeckleObject ).GetTypeInfo().Assembly.GetName();
    private static readonly string SpeckleAssemblyLocation = Path.GetDirectoryName( typeof( SpeckleApiClient ).GetTypeInfo().Assembly.Location );
    private readonly Lazy<IReadOnlyCollection<Assembly>> assemblies = new Lazy<IReadOnlyCollection<Assembly>>( GetAvailableAssemblies );

    /// <summary>
    /// Gets all <see cref="Assembly"/> instances in the catalog.
    /// </summary>
    /// <returns>An <see cref="IReadOnlyCollection{T}"/> of <see cref="Assembly"/> instances.</returns>
    public virtual IReadOnlyCollection<Assembly> GetAssemblies( )
    {
      return this.assemblies.Value;
    }

    private static IReadOnlyCollection<Assembly> GetAvailableAssemblies( )
    {
      var assemblies = GetLoadedSpeckleReferencingAssemblies();

      var loaded = LoadSpeckleReferencingAssemblies( assemblies );

      return assemblies.Union( loaded ).ToArray();
    }

    private static List<Assembly> GetLoadedSpeckleReferencingAssemblies( )
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

    private static IEnumerable<Assembly> LoadSpeckleReferencingAssemblies( IEnumerable<Assembly> loadedAssemblies )
    {
      var assemblies = new HashSet<Assembly>();
      //var inspectionAppDomain = CreateInspectionAppDomain();
      //var inspectionProber = CreateRemoteReferenceProber( inspectionAppDomain );
      var loadedSpeckleReferencingAssemblyNames = loadedAssemblies.Select( assembly => assembly.GetName() ).ToArray();
      var directory = new Uri( SpeckleAssemblyLocation ).LocalPath;

      foreach ( var assemblyPath in System.IO.Directory.EnumerateFiles( directory, "*.dll" ) )
      {
        var unloadedAssemblyName = SafeGetAssemblyName( assemblyPath );

        if ( unloadedAssemblyName == null )
        {
          continue;
        }

        if ( !loadedSpeckleReferencingAssemblyNames.Any( loadedSpeckleReferencingAssemblyName => AssemblyName.ReferenceMatchesDefinition( loadedSpeckleReferencingAssemblyName, unloadedAssemblyName ) ) )
        {
          var test = unloadedAssemblyName;
          var relfectionLoadAssembly = Assembly.ReflectionOnlyLoadFrom( assemblyPath );
          var isReferencing = relfectionLoadAssembly.IsReferencing( SpeckleAssemblyName );

          var boo = isReferencing;
          if(isReferencing)
          {
            Debug.WriteLine( "Load converter: " + unloadedAssemblyName );
            //var assembly = SafeLoadAssembly( AppDomain.CurrentDomain, unloadedAssemblyName );

          }

          //if ( inspectionProber.HasReference( unloadedAssemblyName, SpeckleAssemblyName ) )
          //{
          //  var assembly = SafeLoadAssembly( AppDomain.CurrentDomain, unloadedAssemblyName );

          //  if ( assembly != null )
          //  {
          //    assemblies.Add( assembly );
          //  }
          //}
        }
      }
      //}

      //AppDomain.Unload( inspectionAppDomain );

      return assemblies.ToArray();
    }

    private static AppDomain CreateInspectionAppDomain( )
    {
      var currentAppDomain = AppDomain.CurrentDomain;

      return AppDomain.CreateDomain( "AppDomainAssemblyCatalog", currentAppDomain.Evidence,
          currentAppDomain.SetupInformation );
    }

    private static ProxySpeckleReferenceProber CreateRemoteReferenceProber( AppDomain appDomain )
    {
      return ( ProxySpeckleReferenceProber ) appDomain.CreateInstanceAndUnwrap(
          typeof( ProxySpeckleReferenceProber ).Assembly.FullName,
          typeof( ProxySpeckleReferenceProber ).FullName );
    }

    private static IEnumerable<string> GetAssemblyDirectories( )
    {
      var directories = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath != null
          ? AppDomain.CurrentDomain.SetupInformation.PrivateBinPath.Split( new[ ] { ';' }, StringSplitOptions.RemoveEmptyEntries )
          : new string[ ] { };

      foreach ( var directory in directories.Where( directory => !string.IsNullOrWhiteSpace( directory ) ) )
      {
        yield return directory;
      }

      if ( AppDomain.CurrentDomain.SetupInformation.PrivateBinPathProbe == null )
      {
        yield return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
      }
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

  /// <summary>
  /// Utility class used to probe assembly references.
  /// </summary>
  /// <remarks>
  /// Because this class inherits from <see cref="T:System.MarshalByRefObject"/> it can be used across different <see cref="T:System.AppDomain"/>.
  /// </remarks>
  internal class ProxySpeckleReferenceProber : MarshalByRefObject
  {
    /// <summary>
    /// Determines if the assembly has a reference (dependency) upon another one.
    /// </summary>
    /// <param name="assemblyNameForProbing">The name of the assembly that will be tested.</param>
    /// <param name="referenceAssemblyName">The reference assembly name.</param>
    /// <returns>A boolean value indicating if there is a reference.</returns>
    public bool HasReference( AssemblyName assemblyNameForProbing, AssemblyName referenceAssemblyName )
    {
      var assemblyForInspection = Assembly.ReflectionOnlyLoad( assemblyNameForProbing.Name );

      return assemblyForInspection.IsReferencing( referenceAssemblyName );
    }
  }


}
