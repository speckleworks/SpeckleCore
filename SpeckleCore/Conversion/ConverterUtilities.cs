using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
  /// <summary>
  /// Utility functions.
  /// </summary>
  public partial class Converter
  {
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

    /// <summary>
    /// Returns a stringifed MD5 hash of a string.
    /// </summary>
    /// <param name="str">String from which to generate the hash</param>
    /// <param name="length">If 0, the full hasdh will be returned, otherwise it will be trimmed to the specified lenght</param>
    /// <returns></returns>
    public static string getMd5Hash( string str, int length = 0 )
    {
      using ( System.IO.MemoryStream ms = new System.IO.MemoryStream() )
      {
        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize( ms, str );
        byte[ ] hash;
        using ( System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create() )
        {
          hash = md5.ComputeHash( ms.ToArray() );
          StringBuilder sb = new StringBuilder();
          foreach ( byte bbb in hash )
            sb.Append( bbb.ToString( "X2" ) );

          if ( length != 0 )
            return sb.ToString().ToLower().Substring( 0, length );
          else
            return sb.ToString().ToLower();
        }
      }
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
  }
}
