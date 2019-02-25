using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Extends the functionality of some DTO classes to be more accesible.
/// So wow. Much partial.
/// </summary>

namespace SpeckleCore
{

  public partial class SpeckleObject
  {
    /// <summary>
    /// Generates a truncated (to 12) md5 hash of an object. Set length to zero to get the full hash.
    /// </summary>
    /// <param name="fromWhat"></param>
    public string GetMd5FromObject( object fromWhat, int length = 0 )
    {
      if ( fromWhat == null )
      {
        return "null";
      }
      using ( System.IO.MemoryStream ms = new System.IO.MemoryStream() )
      {
        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize( ms, fromWhat );

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

    /// <summary>
    /// Recomputes the object's current hash; takes into account all values besides the hash itself, which is set to null before the calculation.
    /// </summary>
    public virtual void GenerateHash( )
    {
      this.Hash = null;
      this.Hash = this.GetMd5FromObject( this );
    }

    /// <summary>
    /// Use only for unit conversions. This will not affect the object hashes, thus potentially causing 
    /// inconsistencies if used to save objects on a server.
    /// </summary>
    /// <param name="factor">Scaling factor</param>
    public virtual void Scale( double factor )
    {
      // Implemented object type by object type, if it makes sense. 
    }

    /// <summary>
    /// Scales any speckle objects that can be found in an Dictionary.
    /// </summary>
    /// <param name="dict"></param>
    /// <param name="factor"></param>
    /// <returns></returns>
    internal Dictionary<string, object> ScaleProperties( Dictionary<string, object> dict, double factor )
    {
      if ( dict == null ) return null;
      foreach ( var kvp in dict )
      {
        try
        {
          var scaleMethod = kvp.Value.GetType().GetMethod( "Scale" );
          scaleMethod.Invoke( kvp.Value, new object[ ] { factor } );
        }
        catch ( Exception e )
        {
          Debug.WriteLine( "Error while scaling object." );
        }
      }
      return dict;
    }
  }

  public partial class SpeckleInput : SpeckleObject
  {
    public SpeckleInput( ) { }

    [Newtonsoft.Json.JsonProperty( "name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    [Newtonsoft.Json.JsonProperty( "guid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Guid { get; set; }

    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double Value { get; set; }

    [Newtonsoft.Json.JsonProperty( "inputType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string InputType { get; set; }

    [Newtonsoft.Json.JsonProperty( "max", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double Max { get; set; }

    [Newtonsoft.Json.JsonProperty( "min", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double Min { get; set; }

    [Newtonsoft.Json.JsonProperty( "step", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double Step { get; set; }

    public SpeckleInput( string name, float min, float max, float value, string inputType, string guid )
    {
      this.Name = name;
      this.Guid = guid;
      this.Min = min;
      this.Max = max;
      this.Value = value;
      this.InputType = inputType;
    }
  }

  // Output parameter (price, area)
  public partial class SpeckleOutput : SpeckleObject
  {
    public SpeckleOutput( ) { }
    public string Name { get; set; }
    public string Guid { get; set; }
    public string Value { get; set; }

    public SpeckleOutput( string name, string value, string guid )
    {
      this.Name = name;
      this.Guid = guid;
      this.Value = value;
    }
  }

  public partial class Layer : IEquatable<Layer>
  {
    public Layer( ) { }

    public Layer( string name, string guid, string topology, int objectCount, int startIndex, int orderIndex )
    {
      this.Name = name;
      this.Guid = guid;
      this.Topology = topology;
      this.StartIndex = startIndex;
      this.ObjectCount = objectCount;
      this.OrderIndex = orderIndex;
    }

    public static void DiffLayerLists( IEnumerable<Layer> oldLayers, IEnumerable<Layer> newLayers, ref List<Layer> toRemove, ref List<Layer> toAdd, ref List<Layer> toUpdate )
    {
      toRemove = oldLayers.Except( newLayers, new SpeckleLayerComparer() ).ToList();
      toAdd = newLayers.Except( oldLayers, new SpeckleLayerComparer() ).ToList();
      toUpdate = newLayers.Intersect( oldLayers, new SpeckleLayerComparer() ).ToList();
    }

    public bool Equals( Layer other )
    {
      return this.Guid == other.Guid;
    }
  }

  internal class SpeckleLayerComparer : IEqualityComparer<Layer>
  {
    public bool Equals( Layer x, Layer y )
    {
      return x.Guid == y.Guid;
    }

    public int GetHashCode( Layer obj )
    {
      return obj.Guid.GetHashCode();
    }
  }

}
