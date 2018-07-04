using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    /// Generates a truncated (to 12) md5 hash of an object.
    /// </summary>
    /// <param name="fromWhat"></param>
    public string GetMd5FromObject( object fromWhat, int length = 0 )
    {
      if(fromWhat == null)
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
    /// ovveride this method in a speckle object to generate a geometry hash
    /// </summary>
    public virtual void GenerateHash( )
    {
      this.GeometryHash = this.Type.ToString() + ".";
    }


    /// <summary>
    /// Use only for unit conversions. This will not affect the object hashes, thus potentially causing 
    /// inconsistencies if used to save objects on a server.
    /// </summary>
    /// <param name="factor">Scaling factor</param>
    public virtual void Scale( double factor )
    {
    }

    /// <summary>
    /// Scales any speckle objects that can be found in an Dictionary.
    /// </summary>
    /// <param name="dict"></param>
    /// <param name="factor"></param>
    /// <returns></returns>
    internal Dictionary<string, object> ScaleProperties(Dictionary<string,object> dict, double factor)
    {
      if ( dict == null ) return null;
      foreach(var kvp in dict)
      {
        switch(kvp.Value)
        {
          case Dictionary<string, object> d:
            dict[ kvp.Key ] = ScaleProperties( d, factor );
            break;
          case SpeckleInterval obj:
            obj.Scale( factor );
            break;
          case SpeckleInterval2d obj:
            obj.Scale( factor );
            break;
          case SpecklePoint obj:
            obj.Scale( factor );
            break;
          case SpeckleVector obj:
            obj.Scale( factor );
            break;
          case SpecklePlane obj:
            obj.Scale( factor );
            break;
          case SpeckleLine obj:
            obj.Scale( factor );
            break;
          case SpeckleCircle obj:
            obj.Scale( factor );
            break;
          case SpeckleEllipse obj:
            obj.Scale( factor );
            break;
          case SpeckleArc obj:
            obj.Scale( factor );
            break;
          case SpecklePolyline obj:
            obj.Scale( factor );
            break;
          case SpeckleBox obj:
            obj.Scale( factor );
            break;
          case SpecklePolycurve obj:
            obj.Scale( factor );
            break;
          case SpeckleCurve obj:
            obj.Scale( factor );
            break;
          case SpeckleMesh obj:
            obj.Scale( factor );
            break;
          case SpeckleBrep obj:
            obj.Scale( factor );
            break;
          case SpeckleExtrusion obj:
            obj.Scale( factor );
            break;
          case SpeckleAnnotation obj:
            obj.Scale( factor );
            break;
        }
      }
      return dict;
    }


  }

  public partial class SpeckleBoolean
  {
    public SpeckleBoolean( ) { }

    public SpeckleBoolean( bool value, Dictionary<string, object> properties = null )
    {
      this.Value = value;
      this.Properties = properties;

      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += this.Value.ToString();
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

  }

  public partial class SpeckleNumber
  {
    public SpeckleNumber( ) { }

    public SpeckleNumber( double value, Dictionary<string, object> properties = null )
    {
      this.Value = value;
      this.Properties = properties;

      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += this.Value.ToString();
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

    public static implicit operator double? ( SpeckleNumber n )
    {
      return n.Value;
    }

    public static implicit operator SpeckleNumber( double n )
    {
      return new SpeckleNumber( n );
    }
  }

  public partial class SpeckleString
  {
    public SpeckleString( ) { }

    public SpeckleString( string value, Dictionary<string, object> properties = null )
    {
      this.Value = value;
      this.Properties = properties;

      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this.Value );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

    public static implicit operator string( SpeckleString s )
    {
      return s.Value;
    }

    public static implicit operator SpeckleString( string s )
    {
      return new SpeckleString( s );
    }
  }

  public partial class SpeckleInterval
  {
    public SpeckleInterval( ) { }

    public SpeckleInterval( double start, double end, Dictionary<string, object> properties = null )
    {
      this.Start = start;
      this.End = end;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Start *= factor;
      this.End *= factor;

      this.Properties = ScaleProperties( this.Properties, factor );
      this.GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Start + End );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleInterval2d
  {
    public SpeckleInterval2d( ) { }

    public SpeckleInterval2d( SpeckleInterval U, SpeckleInterval V, Dictionary<string, object> properties = null )
    {
      this.U = U;
      this.V = V;
      this.Properties = properties;

      GenerateHash();
    }

    public SpeckleInterval2d( double start_u, double end_u, double start_v, double end_v, Dictionary<string, object> properties = null )
    {
      this.U = new SpeckleInterval( start_u, end_u );
      this.V = new SpeckleInterval( start_v, end_v );
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.U.Scale( factor );
      this.V.Scale( factor );

      this.Properties = ScaleProperties( this.Properties, factor );
      this.GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( U.GeometryHash + V.GeometryHash );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

  }

  public partial class SpecklePoint
  {
    public SpecklePoint( ) { }

    public SpecklePoint( double x, double y, double z = 0, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Value = new List<double>() { x, y, z };
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Value.Count; i++ ) Value[ i ] *= factor;

      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this.Value );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleVector
  {
    public SpeckleVector( ) { }

    public SpeckleVector( double x, double y, double z = 0, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Value = new List<double>() { x, y, z };
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Value.Count; i++ ) Value[ i ] *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this.Value );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpecklePlane
  {
    public SpecklePlane( ) { }

    public SpecklePlane( SpecklePoint origin, SpeckleVector normal, SpeckleVector XDir, SpeckleVector YDir, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Origin = origin;
      this.Normal = normal;
      this.Xdir = XDir;
      this.Ydir = YDir;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Origin.Scale( factor );
      this.Normal.Scale( factor );
      this.Xdir.Scale( factor );
      this.Ydir.Scale( factor );

      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Origin.GeometryHash + Normal.GeometryHash + Xdir.GeometryHash + Ydir.GeometryHash );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleLine
  {
    public SpeckleLine( ) { }

    public SpeckleLine( IEnumerable<double> coordinatesArray, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Value = coordinatesArray.ToList();
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Value.Count; i++ ) Value[ i ] *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Value );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleCircle
  {
    public SpeckleCircle( ) { }

    public SpeckleCircle( SpecklePlane plane, double radius, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Plane = plane;
      this.Radius = radius;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Plane.Scale( factor );
      this.Radius *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Plane.GeometryHash + Radius );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleArc
  {
    public SpeckleArc( ) { }

    public SpeckleArc( SpecklePlane plane, double radius, double startAngle, double endAngle, double angleRadians, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Plane = plane;
      this.Radius = radius;
      this.StartAngle = startAngle;
      this.EndAngle = endAngle;
      this.AngleRadians = angleRadians;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Radius *= factor;
      this.Plane.Scale( factor );
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Plane.GeometryHash + Radius + StartAngle + EndAngle );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleEllipse
  {
    public SpeckleEllipse( ) { }

    public SpeckleEllipse( SpecklePlane plane, double radius1, double radius2, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Plane = plane;
      this.FirstRadius = radius1;
      this.SecondRadius = radius2;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Plane.Scale( factor );
      this.FirstRadius *= factor; this.SecondRadius *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Plane.GeometryHash + FirstRadius + SecondRadius );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleBox
  {
    public SpeckleBox( ) { }

    public SpeckleBox( SpecklePlane basePlane, SpeckleInterval xSize, SpeckleInterval ySize, SpeckleInterval zSize, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.BasePlane = basePlane;
      this.XSize = xSize;
      this.YSize = ySize;
      this.ZSize = zSize;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.BasePlane.Scale( factor );
      this.XSize.Scale( factor );
      this.YSize.Scale( factor );
      this.ZSize.Scale( factor );
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( BasePlane.GeometryHash + XSize.GeometryHash + YSize.GeometryHash + ZSize.GeometryHash );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

  }

  public partial class SpecklePolyline
  {
    public SpecklePolyline( ) { }

    public SpecklePolyline( IEnumerable<double> coordinatesArray, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Value = coordinatesArray.ToList();
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Value.Count; i++ ) Value[ i ] *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Value );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpecklePolycurve
  {
    public SpecklePolycurve() { }

    public override void Scale( double factor )
    {
      foreach ( var segment in this.Segments )
      {
        switch ( segment )
        {
          case SpeckleCore.SpeckleCurve crv:
            crv.Scale( factor );
            break;
          case SpeckleCore.SpeckleLine crv:
            crv.Scale( factor );
            break;
          case SpeckleCore.SpeckleArc crv:
            crv.Scale( factor );
            break;
          case SpeckleCore.SpecklePolyline crv:
            crv.Scale( factor );
            break;
        }
      }
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Segments.Select( obj => obj.Hash ).ToArray() );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleCurve
  {
    public SpeckleCurve( ) { }

    public SpeckleCurve( SpecklePolyline poly, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.DisplayValue = poly;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Points.Count; i++ ) Points[ i ] *= factor;
      this.DisplayValue.Scale( factor );
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this.DisplayValue.GeometryHash );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

  }

  public partial class SpeckleMesh
  {
    public SpeckleMesh( ) { }

    public SpeckleMesh( double[ ] vertices, int[ ] faces, int[ ] colors, double[ ] texture_coords, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Vertices = vertices.ToList();
      this.Faces = faces.ToList();
      this.Colors = colors.ToList();
      this.ApplicationId = applicationId;

      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      for ( int i = 0; i < Vertices.Count; i++ ) Vertices[ i ] *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( JsonConvert.SerializeObject( Vertices ) + JsonConvert.SerializeObject( Faces ) + JsonConvert.SerializeObject( Colors ) );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleBrep
  {
    public SpeckleBrep( ) { }

    public SpeckleBrep( object rawData, string provenance, SpeckleMesh displayValue, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.RawData = rawData;
      this.Provenance = provenance;
      this.DisplayValue = displayValue;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.DisplayValue.Scale( factor );
      this.Properties = ScaleProperties( this.Properties, factor );

      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this.DisplayValue.GeometryHash );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }

  }

  public partial class SpeckleExtrusion
  {
    public SpeckleExtrusion( ) { }

    public SpeckleExtrusion( SpeckleObject profile, double length, bool capped, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Profile = profile;
      this.Length = length;
      this.Capped = capped;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Length *= factor;
      switch(this.Profile)
      {
        case SpeckleCurve c:
          c.Scale( factor );
          break;
        case SpecklePolycurve p:
          p.Scale( factor );
          break;
        case SpecklePolyline p:
          p.Scale( factor );
          break;
        case SpeckleCircle c:
          c.Scale( factor );
          break;
        case SpeckleArc a:
          a.Scale( factor );
          break;
        case SpeckleEllipse e:
          e.Scale( factor );
          break;
        case SpeckleLine l:
          l.Scale( factor);
          break;
        default:
          break;
      }
      
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( Profile.GeometryHash + Length + Capped );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
    }
  }

  public partial class SpeckleAnnotation : SpeckleObject
  {
    public SpeckleAnnotation( ) { }

    public SpeckleAnnotation( string text, double textHeight, string fontName, bool bold, bool italic, SpecklePlane plane, SpecklePoint location, string applicationId = null, Dictionary<string, object> properties = null )
    {
      this.Text = text;
      this.TextHeight = textHeight;
      this.FontName = fontName;
      this.Bold = bold;
      this.Italic = italic;
      this.Plane = plane;
      this.Location = location;
      this.ApplicationId = applicationId;
      this.Properties = properties;

      GenerateHash();
    }

    public override void Scale( double factor )
    {
      this.Plane.Scale( factor );
      this.Location.Scale( factor );
      this.TextHeight *= factor;
      this.Properties = ScaleProperties( this.Properties, factor );
      GenerateHash();
    }

    public override void GenerateHash( )
    {
      base.GenerateHash();
      this.GeometryHash += GetMd5FromObject( this );
      this.Hash = GetMd5FromObject( this.GeometryHash + GetMd5FromObject( this.Properties ) );
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

public partial class SpeckleInput : SpeckleObject
{
    public SpeckleInput() { }
    
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Name { get; set; }

    [Newtonsoft.Json.JsonProperty("guid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Guid { get; set; }

    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public float Value { get; set; }

    [Newtonsoft.Json.JsonProperty("inputType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string InputType { get; set; }

    [Newtonsoft.Json.JsonProperty("max", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public float Max { get; set; }

    [Newtonsoft.Json.JsonProperty("min", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public float Min { get; set; }

    public SpeckleInput(string name, float min, float max, float value, string inputType, string guid)
    {
        this.Name = name;
        this.Guid = guid;
        this.Min = min;
        this.Max = max;
        this.Value = value;
        this.InputType = inputType;
    }
}
  public partial class SpeckleOutput : SpeckleObject
    {
        public SpeckleOutput() { }
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Value { get; set; }

        public SpeckleOutput(string name, string value, string guid)
        {
            this.Name = name;
            this.Guid = guid;
            this.Value = value;
        }
    }
}
