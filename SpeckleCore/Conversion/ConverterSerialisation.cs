using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
  public abstract partial class Converter
  {
    /// <summary>
    /// This method will convert an object to a SpeckleObject, if possible.
    /// </summary>
    /// <param name="o">The object.</param>
    /// <returns>Null or a speckle object (SpeckleAbstract if no explicit conversion method is found).</returns>
    public static List<SpeckleObject> Serialise( IEnumerable<object> objectList, IEnumerable<string> excludeAssebmlies = null )
    {
      return objectList.Select( obj => Serialise( obj, excludeAssebmlies: excludeAssebmlies ) ).ToList();
    }

    /// <summary>
    /// Serialises an object to a speckle object.
    /// </summary>
    /// <param name="source">The object you want to serialise.</param>
    /// <param name="recursionDepth">Leave this blank, unless you really know what you're doing.</param>
    /// <param name="traversed">Leave this blank, unless you really know what you're doing.</param>
    /// <param name="path">Leave this blank, unless you really know what you're doing.</param>
    /// <param name="excludeAssebmlies">List of speckle kits assembly names to exclude from the search.</param>
    /// <returns></returns>
    public static SpeckleObject Serialise( object source, int recursionDepth = 0, Dictionary<int, string> traversed = null, string path = "", IEnumerable<string> excludeAssebmlies = null )
    {
      if ( source == null ) return new SpeckleNull();

      if ( traversed == null ) traversed = new Dictionary<int, string>();

      if ( path == "" ) path = "root";

      // check references
      if ( traversed.ContainsKey( source.GetHashCode() ) )
        return new SpeckleAbstract() { _type = "ref", _ref = traversed[ source.GetHashCode() ] };
      else
        traversed.Add( source.GetHashCode(), path );

      // check if it already is a speckle object
      if ( source is SpeckleObject )
        return source as SpeckleObject;

      // check assemblies
      if ( toSpeckleMethods.ContainsKey( source.GetType().ToString() ) )
        return toSpeckleMethods[ source.GetType().ToString() ].Invoke( source, new object[ ] { source } ) as SpeckleObject;

      var methods = new List<MethodInfo>();
      foreach ( var ass in SpeckleCore.SpeckleInitializer.GetAssemblies().Where( ass => ( excludeAssebmlies != null ? !excludeAssebmlies.Contains( ass.FullName ) : true ) ) )
      {
        try
        {
          methods.AddRange( Converter.GetExtensionMethods( ass, source.GetType(), "ToSpeckle" ) );
        }
        catch { } // handling errors thrown when we're attempting to load something with missing references (ie, dynamo stuff in rhino, or vice-versa).
      }

      // if we have a "ToSpeckle" extension method, then invoke that and return its result
      if ( methods.Count > 0 )
      {
        try
        {
          var obj = methods[ 0 ].Invoke( source, new object[ ] { source } );
          if ( obj != null )
          {
            toSpeckleMethods.Add( source.GetType().ToString(), methods[ 0 ] );
            return obj as SpeckleObject;
          }
          else
          {
            return new SpeckleNull();
          }
        }
        catch
        {
          return new SpeckleNull();
        }
      }

      // else just continue with the to abstract part
      SpeckleAbstract result = new SpeckleAbstract();
      result._type = source.GetType().Name;
      result._assembly = source.GetType().Assembly.FullName;

      Dictionary<string, object> dict = new Dictionary<string, object>();

      var properties = source.GetType().GetProperties( BindingFlags.Instance | BindingFlags.Public );

      foreach ( var prop in properties )
      {
        if ( !prop.CanWrite )
          continue;

        try
        {
          var value = prop.GetValue( source );

          if ( value == null )
            continue;

          dict[ prop.Name ] = WriteValue( value, recursionDepth, traversed, path + "/" + prop.Name );
        }
        catch { }
      }

      var fields = source.GetType().GetFields( BindingFlags.Instance | BindingFlags.Public );
      foreach ( var field in fields )
      {
        if ( field.IsNotSerialized )
          continue;
        try
        {
          var value = field.GetValue( source );
          if ( value == null )
            continue;
          dict[ field.Name ] = WriteValue( value, recursionDepth, traversed, path + "/" + field.Name );
        }
        catch { }
      }

      result.Properties = dict;
      result.Hash = result.GeometryHash = result.GetMd5FromObject( result.Properties );

      return result;
    }

    private static object WriteValue( object myObject, int recursionDepth, Dictionary<int, string> traversed = null, string path = "" )
    {
      if ( myObject == null || recursionDepth > 8 ) return null;

      if ( myObject is Enum ) return Convert.ChangeType( ( Enum ) myObject, ( ( Enum ) myObject ).GetTypeCode() );

      if ( myObject.GetType().IsPrimitive || myObject is string )
        return myObject;

      if ( myObject is Guid )
        return myObject.ToString();

      if ( myObject is IEnumerable && !( myObject is IDictionary ) )
      {
        var rlist = new List<object>(); int index = 0;

        foreach ( var x in ( IEnumerable ) myObject )
        {
          var obj = WriteValue( x, recursionDepth + 1, traversed, path + "/[" + index++ + "]" );
          if ( obj != null )
            rlist.Add( obj );
        }
        return rlist;
      }

      if ( myObject is IDictionary )
      {
        var myDict = myObject as IDictionary;
        var returnDict = new Dictionary<string, object>();
        foreach ( DictionaryEntry x in myDict )
        {
          var y = x.Key;
          returnDict.Add( x.Key.ToString(), WriteValue( x.Value, recursionDepth, traversed, path + "/{" + x.Key.ToString() + "}" ) );
        }
        return returnDict;
      }

      if ( !myObject.GetType().AssemblyQualifiedName.Contains( "System" ) )
        return Converter.Serialise( myObject, recursionDepth + 1, traversed, path );

      return null;
    }
  }
}
