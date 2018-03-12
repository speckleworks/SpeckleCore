using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
  /// <summary>
  /// A basic abstract class that all Speckle converters should implement. 
  /// Provided some convenience methods for casting POCOs to SpeckleAbstract types. 
  /// </summary>
  public abstract class Converter
  {
    public abstract IEnumerable<SpeckleObject> ToSpeckle( IEnumerable<object> _objects );
    public abstract SpeckleObject ToSpeckle( object _object );

    public abstract IEnumerable<object> ToNative( IEnumerable<SpeckleObject> _objects );
    public abstract object ToNative( SpeckleObject _object );

    public static Dictionary<string, MethodInfo> toSpeckleMethods = new Dictionary<string, MethodInfo>();

    public static Dictionary<string, MethodInfo> toNativeMethods = new Dictionary<string, MethodInfo>();


    public static string getBase64( object obj )
    {
      using ( System.IO.MemoryStream ms = new System.IO.MemoryStream() )
      {
        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize( ms, obj );
        return Convert.ToBase64String( ms.ToArray() );
      }
    }

    public static byte[ ] getBytes( object obj )
    {
      using ( System.IO.MemoryStream ms = new System.IO.MemoryStream() )
      {
        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize( ms, obj );
        return ms.ToArray();
      }
    }

    public static object getObjFromString( string base64String )
    {
      if ( base64String == null ) return null;
      byte[ ] bytes = Convert.FromBase64String( base64String );
      return getObjFromBytes( bytes );
    }

    public static object getObjFromBytes( byte[ ] bytes )
    {
      using ( System.IO.MemoryStream ms = new System.IO.MemoryStream( bytes, 0, bytes.Length ) )
      {
        ms.Write( bytes, 0, bytes.Length );
        ms.Position = 0;
        return new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Deserialize( ms );
      }
    }

    public static string bytesToBase64( byte[ ] arr )
    {
      return Convert.ToBase64String( arr );
    }

    public static byte[ ] base64ToBytes( string str )
    {
      return Convert.FromBase64String( str );
    }

    // https://stackoverflow.com/a/299526/3446736
    private static IEnumerable<MethodInfo> GetExtensionMethods( Assembly assembly, Type extendedType, string methodName )
    {
      var query = from type in assembly.GetTypes()
                  where type.IsSealed && !type.IsGenericType && !type.IsNested
                  from method in type.GetMethods( BindingFlags.Static
                    | BindingFlags.Public | BindingFlags.NonPublic )
                  where method.IsDefined( typeof( System.Runtime.CompilerServices.ExtensionAttribute ), false )
                  where method.GetParameters()[ 0 ].ParameterType == extendedType
                  where method.Name == methodName
                  select method;
      return query;
    }

    /// <summary>
    /// This method will convert an object to a SpeckleObject, if possible.
    /// It will look for an extension method called "ToSpeckle" in all the plausible loaded assemblies (the assembly name needs to contain "Speckle" and "Converter"). If found, it will invoke it and return its output. Otherwise, it will try and convert the object to a SpeckleAbstract object. If it fails, returns null.
    /// </summary>
    /// <param name="o">The object.</param>
    /// <returns>Null or a speckle object (SpeckleAbstract if no explicit conversion method is found).</returns>
    public static List<SpeckleObject> Serialise( IEnumerable<object> objectList )
    {
      return objectList.Select( obj => Serialise( obj ) ).ToList();
    }


    /// <summary>
    /// Deserialises a list of speckle objects.
    /// </summary>
    /// <param name="o">The object.</param>
    /// <returns>A native type, a SpeckleAbstract if no explicit conversion found, or null.</returns>
    public static List<object> Deserialise( IEnumerable<SpeckleObject> objectList )
    {
      return objectList.Select( obj => Deserialise( obj ) ).ToList();
    }

    /// <summary>                                                  
    /// Deserialises a speckle object.                             
    /// </summary>                                                 
    /// <param name="obj"></param>
    /// <returns>an object, a SpeckleAbstract or null.</returns>
    public static object Deserialise( SpeckleObject obj, object root = null )
    {
      try
      {
        // null check
        if ( obj == null ) return null;

        // if it's not a speckle abstract object
        if ( !( obj is SpeckleAbstract ) )
        {
          // assembly check 
          var type = obj.GetType().ToString();

          if ( toNativeMethods.ContainsKey( type ) )
            return toNativeMethods[ obj.GetType().ToString() ].Invoke( obj, new object[ ] { obj } );

          List<Assembly> myAss = System.AppDomain.CurrentDomain.GetAssemblies().ToList().FindAll( s => s.FullName.Contains( "Speckle" ) && s.FullName.Contains( "Converter" ) );

          List<MethodInfo> methods = new List<MethodInfo>();

          foreach ( var ass in myAss )
            methods.AddRange( Converter.GetExtensionMethods( ass, obj.GetType(), "ToNative" ) );

          // if we have some ToNative method
          if ( methods.Count > 0 )
          {
            toNativeMethods.Add( type, methods[ 0 ] );
            var result = methods[ 0 ].Invoke( obj, new object[ ] { obj } );
            if ( result != null ) return result;
          }
          // otherwise return null
          return null;
        }
        else
        {
          // we have a speckle abstract object
          SpeckleAbstract absObj = obj as SpeckleAbstract;

          if ( absObj._Type == "ref" )
            return null;

          var assembly = System.AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault( a => a.FullName == absObj._Assembly );

          if ( assembly == null ) // we can't deserialise for sure
            return Converter.ShallowConvert( absObj );

          var type = assembly.GetTypes().FirstOrDefault( t => t.Name == absObj._Type );
          if ( type == null ) // type not present in the assembly
            return Converter.ShallowConvert( absObj );

          object myObject = null;

          try
          {
            var constructor = type.GetConstructor( BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[ ] { }, null );
            if ( constructor != null )
              myObject = constructor.Invoke( new object[ ] { } );
            if ( myObject == null )
              myObject = Activator.CreateInstance( type );
          }
          catch
          {
            myObject = System.Runtime.Serialization.FormatterServices.GetUninitializedObject( type );
          }

          if ( myObject == null )
            return null;

          if ( root == null )
            root = myObject;

          var keys = absObj.Properties.Keys;
          foreach ( string key in keys )
          {
            var prop = TryGetProperty( type, key );
            var field = type.GetField( key );

            if ( prop == null && field == null ) continue;

            if ( absObj.Properties[ key ] == null ) continue;

            var value = ReadValue( absObj.Properties[ key ], root );

            // handles both hashsets and lists or whatevers
            if ( value is IEnumerable && !( value is IDictionary ) && value.GetType() != typeof( string ) )
            {
              try
              {
                var mySubList = Activator.CreateInstance( prop != null ? prop.PropertyType : field.FieldType );
                foreach ( var myObj in ( ( IEnumerable<object> ) value ) )
                  mySubList.GetType().GetMethod( "Add" ).Invoke( mySubList, new object[ ] { myObj } );

                value = mySubList;
              }
              catch { }
            }

            // handles dictionaries of all sorts (kind-of!)
            if ( value is IDictionary )
            {
              try
              {
                var MyDict = Activator.CreateInstance( prop != null ? prop.PropertyType : field.FieldType );

                foreach ( DictionaryEntry kvp in ( IDictionary ) value )
                  MyDict.GetType().GetMethod( "Add" ).Invoke( MyDict, new object[ ] { Convert.ChangeType( kvp.Key, MyDict.GetType().GetGenericArguments()[ 0 ] ), kvp.Value } );

                value = MyDict;
              }
              catch ( Exception e )
              {
                System.Diagnostics.Debug.WriteLine( e.Message );
              }
            }

            // guids are a pain
            if ( ( prop != null && prop.PropertyType == typeof( Guid ) ) || ( field != null && field.FieldType == typeof( Guid ) ) )
              value = new Guid( ( string ) value );

            // Actually set the value below, whether it's a property or field
            // if it is a property
            if ( prop != null && prop.CanWrite )
            {
              if ( prop.PropertyType.IsEnum )
                prop.SetValue( myObject, Enum.ToObject( prop.PropertyType, Convert.ChangeType( value, TypeCode.Int32 ) ) );
              else
              {
                try
                {
                  prop.SetValue( myObject, value );
                }
                catch
                {
                  try
                  {
                    prop.SetValue( myObject, Convert.ChangeType( value, prop.PropertyType ) );
                  }
                  catch { }
                }
              }
            }
            // if it is a field
            else if ( field != null )
            {
              if ( field.FieldType.IsEnum )
                field.SetValue( myObject, Enum.ToObject( field.FieldType, Convert.ChangeType( value, TypeCode.Int32 ) ) );
              else
              {
                try
                {
                  field.SetValue( absObj, value );
                }
                catch
                {
                  try
                  {
                    field.SetValue( myObject, Convert.ChangeType( value, field.FieldType ) );
                  }
                  catch { }
                }
              }
            }
          }

          //  set references too.
          if ( root == myObject )
            Converter.ResolveRefs( absObj, myObject, "root" );

          return myObject;
        }
      }
      catch
      {
        return null;
      }
    }

    private static object ShallowConvert( SpeckleAbstract obj )
    {
      var keys = obj.Properties.Keys;
      var newDict = new Dictionary<string, object>();
      foreach ( string key in keys )
      {
        newDict.Add( key, Converter.ReadValue( obj.Properties[ key ], obj ) );
      }
      obj.Properties = newDict;
      return obj;
    }

    private static object ReadValue( object myObject, object root = null )
    {
      if ( myObject == null ) return null;

      if ( myObject.GetType().IsPrimitive || myObject.GetType() == typeof( string ) )
        return myObject;

      if ( myObject is SpeckleAbstract )
        return Converter.Deserialise( ( SpeckleAbstract ) myObject, root );

      if ( myObject is SpeckleObject )
        return Converter.Deserialise( ( SpeckleObject ) myObject );

      if ( myObject is IEnumerable<object> )
        return ( ( IEnumerable<object> ) myObject ).Select( o => ReadValue( o, root ) ).ToList();

      if ( myObject is IDictionary )
      {
        var genericDict = new Dictionary<object, object>();
        foreach ( DictionaryEntry kvp in ( IDictionary ) myObject )
          genericDict.Add( kvp.Key, ReadValue( kvp.Value, root ) );
        return genericDict;
      }

      return null;
    }

    private static void ResolveRefs( object original, object root, string currentPath )
    {
      if ( original is SpeckleAbstract )
      {
        SpeckleAbstract myObj = ( SpeckleAbstract ) original;
        if ( myObj._Type == "ref" )
          Converter.LinkRef( root, myObj._Ref, currentPath );
        else
          foreach ( var key in myObj.Properties.Keys )
            Converter.ResolveRefs( myObj.Properties[ key ], root, currentPath + "/" + key );
      }

      if ( original is IDictionary )
      {
        foreach ( DictionaryEntry kvp in ( IDictionary ) original )
          Converter.ResolveRefs( kvp.Value, root, currentPath + "/{" + kvp.Key.ToString() + "}" );
      }

      if ( original is List<object> )
      {
        List<object> myList = ( List<object> ) original; int index = 0;
        foreach ( object obj in myList )
          Converter.ResolveRefs( obj, root, currentPath + "/[" + index++ + "]" );
      }
    }

    private static void LinkRef( object target, string fromWhere, string toWhere )
    {
      var sourceAddress = fromWhere.Split( '/' );
      var targetAddress = toWhere.Split( '/' );

      object propSource = target;
      foreach ( string s in sourceAddress )
      {
        if ( s == "root" ) continue;
        if ( s.Contains( "{" ) ) // special handler for dicts
        {
          var keySrc = s.Substring( 1, s.Length - 2 );
          propSource = ( ( IDictionary ) propSource )[ Convert.ChangeType( keySrc, ( ( IDictionary ) propSource ).GetType().GetGenericArguments()[ 0 ] ) ];
          continue;
        }
        if ( s.Contains( "[" ) ) // special handler for lists
        {
          propSource = ( ( IEnumerable<object> ) propSource ).ToList()[ int.Parse( s.Substring( 1, s.Length - 2 ) ) ];
          continue;
        }
        var propertySource = TryGetProperty( propSource, s );
        if ( propertySource != null )
        {
          propSource = propertySource.GetValue( propSource );
        }
        else
        {
          propSource = propSource.GetType().GetField( s ).GetValue( propSource );
        }
      }

      object propTarget = target;
      for ( int i = 1; i < targetAddress.Length - 1; i++ )
      {
        var s = targetAddress[ i ];

        if ( s == "root" ) continue;
        if ( s.Contains( "{" ) ) // special handler for dicts
        {
          var keySrc = s.Substring( 1, s.Length - 2 );
          propTarget = ( ( IDictionary ) propTarget )[ Convert.ChangeType( keySrc, ( ( IDictionary ) propTarget ).GetType().GetGenericArguments()[ 0 ] ) ];
          //propTarget = ( ( Dictionary<string, object> ) propTarget )[ s.Substring( 1, s.Length - 2 ) ];
          continue;
        }

        if ( s.Contains( "[" ) ) // special handler for lists
        {
          propTarget = ( ( IList ) propTarget )[ int.Parse( s.Substring( 1, s.Length - 2 ) ) ];
          continue;
        }

        var propertyTarget = TryGetProperty( propTarget.GetType(), s );
        if ( propertyTarget != null )
        {
          propTarget = propertyTarget.GetValue( propTarget );
        }
        else
        {
          propTarget = propTarget.GetType().GetField( s ).GetValue( propTarget );
        }
      }

      var last = targetAddress.Last();

      if ( last.Contains( '{' ) )
      {
        var keySrc = last.Substring( 1, last.Length - 2 );
        ( ( IDictionary ) propTarget )[ Convert.ChangeType( keySrc, ( ( IDictionary ) propTarget ).GetType().GetGenericArguments()[ 0 ] ) ] = propSource;
        //( ( Dictionary<string, object> ) propTarget )[ last.Substring( 1, last.Length - 2 ) ] = propSource;
        return;
      }
      if ( last.Contains( '[' ) )
      {
        ( ( IList ) propTarget )[ int.Parse( last.Substring( 1, last.Length - 2 ) ) ] = propSource;
        return;
      }
      PropertyInfo toSet = TryGetProperty( propTarget.GetType(), last );
      if ( toSet != null )
      {
        if ( toSet.CanWrite )
          toSet.SetValue( propTarget, propSource, null );
      }
      else
      {
        var toSetField = propTarget.GetType().GetField( last );
        toSetField.SetValue( propTarget, propSource );
      }
    }

    private static PropertyInfo TryGetProperty( object obj, string name )
    {
      return TryGetProperty( obj.GetType(), name );
    }
    private static PropertyInfo TryGetProperty( Type type, string name )
    {
      try
      {
        return type.GetProperty( name );
      }
      catch ( AmbiguousMatchException )
      {
        PropertyInfo property = null;
        Type declaringType = null;
        foreach ( var propInfo in type.GetProperties() )
        {
          if ( string.Compare( name, propInfo.Name ) == 0 )
          {
            if ( property == null || propInfo.DeclaringType.IsSubclassOf( declaringType ) )
            {
              property = propInfo;
              declaringType = propInfo.DeclaringType;
            }
          }
        }
        return property;
      }
    }

    /// <summary>
    /// Serialises an object to a speckle object.
    /// </summary>
    /// <param name="source">The object you want to serialise.</param>
    /// <param name="recursionDepth">Leave this blank, unless you really know what you're doing.</param>
    /// <param name="traversed">Leave this blank, unless you really know what you're doing.</param>
    /// <param name="path">Leave this blank, unless you really know what you're doing.</param>
    /// <returns></returns>
    public static SpeckleObject Serialise( object source, int recursionDepth = 0, Dictionary<int, string> traversed = null, string path = "" )
    {
      // null  check
      if ( source == null ) return null;

      // init optional parameters
      if ( traversed == null ) traversed = new Dictionary<int, string>();

      if ( path == "" ) path = "root";

      // check references
      if ( traversed.ContainsKey( source.GetHashCode() ) )
        return new SpeckleAbstract() { _Type = "ref", _Ref = traversed[ source.GetHashCode() ] };
      else
        traversed.Add( source.GetHashCode(), path );

      // check if it already is a speckle object
      if ( source is SpeckleObject ) return source as SpeckleObject;

      // check assemblies
      if ( toSpeckleMethods.ContainsKey( source.GetType().ToString() ) )
        return toSpeckleMethods[ source.GetType().ToString() ].Invoke( source, new object[ ] { source } ) as SpeckleObject;

      List<Assembly> myAss = System.AppDomain.CurrentDomain.GetAssemblies().ToList().FindAll( s => s.FullName.Contains( "Speckle" ) && s.FullName.Contains( "Converter" ) );

      List<MethodInfo> methods = new List<MethodInfo>();
      foreach ( var ass in myAss )
        methods.AddRange( Converter.GetExtensionMethods( ass, source.GetType(), "ToSpeckle" ) );

      // if we have a "ToSpeckle" extension method, then invoke that and return its result
      if ( methods.Count > 0 )
      {
        return methods[ 0 ].Invoke( source, new object[ ] { source } ) as SpeckleObject;
      }

      // else just continue with the to abstract part
      SpeckleAbstract result = new SpeckleAbstract();
      result._Type = source.GetType().Name;
      result._Assembly = source.GetType().Assembly.FullName;

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
      result.SetHashes( result.Properties );

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
