using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public enum SpeckleObjectType
  {
    [System.Runtime.Serialization.EnumMember( Value = "Null" )]
    Null = 0,

    [System.Runtime.Serialization.EnumMember( Value = "Abstract" )]
    Abstract = 1,

    [System.Runtime.Serialization.EnumMember( Value = "Placeholder" )]
    Placeholder = 2,

    [System.Runtime.Serialization.EnumMember( Value = "Boolean" )]
    Boolean = 3,

    [System.Runtime.Serialization.EnumMember( Value = "Number" )]
    Number = 4,

    [System.Runtime.Serialization.EnumMember( Value = "String" )]
    String = 5,

    [System.Runtime.Serialization.EnumMember( Value = "Interval" )]
    Interval = 6,

    [System.Runtime.Serialization.EnumMember( Value = "Interval2d" )]
    Interval2d = 7,

    [System.Runtime.Serialization.EnumMember( Value = "Point" )]
    Point = 8,

    [System.Runtime.Serialization.EnumMember( Value = "Vector" )]
    Vector = 9,

    [System.Runtime.Serialization.EnumMember( Value = "Plane" )]
    Plane = 10,

    [System.Runtime.Serialization.EnumMember( Value = "Line" )]
    Line = 11,

    [System.Runtime.Serialization.EnumMember( Value = "Rectangle" )]
    Rectangle = 12,

    [System.Runtime.Serialization.EnumMember( Value = "Circle" )]
    Circle = 13,

    [System.Runtime.Serialization.EnumMember( Value = "Arc" )]
    Arc = 14,

    [System.Runtime.Serialization.EnumMember( Value = "Ellipse" )]
    Ellipse = 15,

    [System.Runtime.Serialization.EnumMember( Value = "Polycurve" )]
    Polycurve = 16,

    [System.Runtime.Serialization.EnumMember( Value = "Box" )]
    Box = 17,

    [System.Runtime.Serialization.EnumMember( Value = "Polyline" )]
    Polyline = 18,

    [System.Runtime.Serialization.EnumMember( Value = "Curve" )]
    Curve = 19,

    [System.Runtime.Serialization.EnumMember( Value = "Mesh" )]
    Mesh = 20,

    [System.Runtime.Serialization.EnumMember( Value = "Brep" )]
    Brep = 21,

    [System.Runtime.Serialization.EnumMember( Value = "Annotation" )]
    Annotation = 22,

    [System.Runtime.Serialization.EnumMember( Value = "Extrusion" )]
    Extrusion = 23,

    [System.Runtime.Serialization.EnumMember( Value = "Block" )]
    Block = 24

  }

  /// <summary>Base class that is inherited by all other Speckle objects.</summary>
  [Newtonsoft.Json.JsonConverter( typeof( SpeckleObjectConverter ), "type" )]
  [JsonInheritanceAttribute( "SpeckleAbstract", typeof( SpeckleAbstract ) )]
  [JsonInheritanceAttribute( "SpecklePlaceholder", typeof( SpecklePlaceholder ) )]
  [JsonInheritanceAttribute( "SpeckleBoolean", typeof( SpeckleBoolean ) )]
  [JsonInheritanceAttribute( "SpeckleNumber", typeof( SpeckleNumber ) )]
  [JsonInheritanceAttribute( "SpeckleString", typeof( SpeckleString ) )]
  [JsonInheritanceAttribute( "SpeckleInterval", typeof( SpeckleInterval ) )]
  [JsonInheritanceAttribute( "SpeckleInterval2d", typeof( SpeckleInterval2d ) )]
  [JsonInheritanceAttribute( "SpecklePoint", typeof( SpecklePoint ) )]
  [JsonInheritanceAttribute( "SpeckleVector", typeof( SpeckleVector ) )]
  [JsonInheritanceAttribute( "SpecklePlane", typeof( SpecklePlane ) )]
  [JsonInheritanceAttribute( "SpeckleCircle", typeof( SpeckleCircle ) )]
  [JsonInheritanceAttribute( "SpeckleArc", typeof( SpeckleArc ) )]
  [JsonInheritanceAttribute( "SpeckleEllipse", typeof( SpeckleEllipse ) )]
  [JsonInheritanceAttribute( "SpecklePolycurve", typeof( SpecklePolycurve ) )]
  [JsonInheritanceAttribute( "SpeckleBox", typeof( SpeckleBox ) )]
  [JsonInheritanceAttribute( "SpecklePolyline", typeof( SpecklePolyline ) )]
  [JsonInheritanceAttribute( "SpeckleCurve", typeof( SpeckleCurve ) )]
  [JsonInheritanceAttribute( "SpeckleMesh", typeof( SpeckleMesh ) )]
  [JsonInheritanceAttribute( "SpeckleBrep", typeof( SpeckleBrep ) )]
  [JsonInheritanceAttribute( "SpeckleExtrusion", typeof( SpeckleExtrusion ) )]
  [JsonInheritanceAttribute( "SpeckleAnnotation", typeof( SpeckleAnnotation ) )]
  [JsonInheritanceAttribute( "SpeckleBlock", typeof( SpeckleBlock ) )]
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleObject : ResourceBase
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Abstract;

    /// <summary>Object's unique hash.</summary>
    [Newtonsoft.Json.JsonProperty( "hash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Hash { get; set; }

    /// <summary>Object's geometry hash</summary>
    [Newtonsoft.Json.JsonProperty( "geometryHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string GeometryHash { get; set; }

    /// <summary>The id/guid that the origin application identifies this object by.</summary>
    [Newtonsoft.Json.JsonProperty( "applicationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string ApplicationId { get; set; }

    /// <summary>The extra properties field of a speckle object.</summary>
    [Newtonsoft.Json.JsonProperty( "properties", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( SpecklePropertiesConverter ) )]
    public Dictionary<string, object> Properties { get; set; }

    /// <summary>If this object is a child, the parent's objectid.</summary>
    [Newtonsoft.Json.JsonProperty( "parent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Parent { get; set; }

    /// <summary>An array of the ids of any children of this object.</summary>
    [Newtonsoft.Json.JsonProperty( "children", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Children { get; set; }

    /// <summary>If resulting from a merge, the objects that this one was born out of.</summary>
    [Newtonsoft.Json.JsonProperty( "ancestors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Ancestors { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleObject FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleObject>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleAbstract : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Abstract;

    /// <summary>the original type of the object</summary>
    [Newtonsoft.Json.JsonProperty( "_type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _type { get; set; }

    /// <summary>the original type of the object</summary>
    [Newtonsoft.Json.JsonProperty( "_ref", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _ref { get; set; }

    /// <summary>the original assembly of this object</summary>
    [Newtonsoft.Json.JsonProperty( "_assembly", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _assembly { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleAbstract FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleAbstract>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpecklePlaceholder : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Placeholder;

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpecklePlaceholder FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpecklePlaceholder>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleBoolean : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Boolean;

    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Value { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleBoolean FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleBoolean>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleNumber : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Number;

    /// <summary>A number. Can be float, double, etc.</summary>
    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Value { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleNumber FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleNumber>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleString : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.String;

    /// <summary>A string.</summary>
    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Value { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleString FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleString>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleInterval : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Interval;

    [Newtonsoft.Json.JsonProperty( "start", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Start { get; set; }

    [Newtonsoft.Json.JsonProperty( "end", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? End { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleInterval FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleInterval>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleInterval2d : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Interval2d;

    /// <summary>U interval.</summary>
    [Newtonsoft.Json.JsonProperty( "U", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval U { get; set; }

    /// <summary>V interval.</summary>
    [Newtonsoft.Json.JsonProperty( "V", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval V { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleInterval2d FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleInterval2d>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpecklePoint : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Point;

    /// <summary>An array containing the X, Y and Z coords of the point.</summary>
    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpecklePoint FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpecklePoint>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleVector : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Vector;

    /// <summary>An array containing the X, Y and Z coords of the vector.</summary>
    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleVector FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleVector>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpecklePlane : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Plane;

    /// <summary>The origin of the plane.</summary>
    [Newtonsoft.Json.JsonProperty( "origin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePoint Origin { get; set; }

    /// <summary>The normal of the plane.</summary>
    [Newtonsoft.Json.JsonProperty( "normal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleVector Normal { get; set; }

    /// <summary>The X axis of the plane.</summary>
    [Newtonsoft.Json.JsonProperty( "xdir", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleVector Xdir { get; set; }

    /// <summary>The Y axis of the plane.</summary>
    [Newtonsoft.Json.JsonProperty( "ydir", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleVector Ydir { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpecklePlane FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpecklePlane>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleCircle : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Circle;

    [Newtonsoft.Json.JsonProperty( "radius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Radius { get; set; }

    [Newtonsoft.Json.JsonProperty( "center", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePoint Center { get; set; }

    [Newtonsoft.Json.JsonProperty( "normal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleVector Normal { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleCircle FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleCircle>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleArc : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Arc;

    [Newtonsoft.Json.JsonProperty( "radius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Radius { get; set; }

    [Newtonsoft.Json.JsonProperty( "startAngle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? StartAngle { get; set; }

    [Newtonsoft.Json.JsonProperty( "endAngle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? EndAngle { get; set; }

    [Newtonsoft.Json.JsonProperty( "angleRadians", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? AngleRadians { get; set; }

    [Newtonsoft.Json.JsonProperty( "plane", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleArc FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleArc>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleEllipse : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Ellipse;

    [Newtonsoft.Json.JsonProperty( "firstRadius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? FirstRadius { get; set; }

    [Newtonsoft.Json.JsonProperty( "secondRadius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? SecondRadius { get; set; }

    [Newtonsoft.Json.JsonProperty( "plane", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleEllipse FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleEllipse>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpecklePolycurve : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Polycurve;

    [Newtonsoft.Json.JsonProperty( "segments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<SpeckleObject> Segments { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpecklePolycurve FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpecklePolycurve>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleBox : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Box;

    [Newtonsoft.Json.JsonProperty( "basePlane", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePlane BasePlane { get; set; }

    [Newtonsoft.Json.JsonProperty( "xSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval XSize { get; set; }

    [Newtonsoft.Json.JsonProperty( "ySize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval YSize { get; set; }

    [Newtonsoft.Json.JsonProperty( "zSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval ZSize { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleBox FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleBox>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleLine : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Line;

    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpecklePolyline FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpecklePolyline>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpecklePolyline : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Polyline;

    [Newtonsoft.Json.JsonProperty( "value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Value { get; set; }

    [Newtonsoft.Json.JsonProperty( "closed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool closed { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpecklePolyline FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpecklePolyline>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleCurve : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Curve;

    [Newtonsoft.Json.JsonProperty( "degree", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public int Degree { get; set; }

    [Newtonsoft.Json.JsonProperty( "periodic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool Periodic { get; set; }

    [Newtonsoft.Json.JsonProperty( "rational", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool Rational { get; set; }

    [Newtonsoft.Json.JsonProperty( "points", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Points { get; set; }

    [Newtonsoft.Json.JsonProperty( "weights", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Weights { get; set; }

    [Newtonsoft.Json.JsonProperty( "knots", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Knots { get; set; }

    [Newtonsoft.Json.JsonProperty( "domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleInterval Domain { get; set; }

    [Newtonsoft.Json.JsonProperty( "displayValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePolyline DisplayValue { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleCurve FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleCurve>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleMesh : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Mesh;

    /// <summary>The mesh's vertices array, in a flat array (ie, `x1, y1, z1, x2, y2, ...`)</summary>
    [Newtonsoft.Json.JsonProperty( "vertices", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Vertices { get; set; }

    /// <summary>The faces array.</summary>
    [Newtonsoft.Json.JsonProperty( "faces", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<int> Faces { get; set; }

    /// <summary>If any, the colours per vertex.</summary>
    [Newtonsoft.Json.JsonProperty( "colors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<int> Colors { get; set; }

    /// <summary>If any, the colours per vertex.</summary>
    [Newtonsoft.Json.JsonProperty( "textureCoordinates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> TextureCoordinates { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleMesh FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleMesh>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleBrep : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Brep;

    /// <summary>The brep's raw (serialisation) data.</summary>
    [Newtonsoft.Json.JsonProperty( "rawData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public object RawData { get; set; }

    /// <summary>A short prefix of where the base64 comes from.</summary>
    [Newtonsoft.Json.JsonProperty( "provenance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Provenance { get; set; }

    /// <summary>Contains a speckle mesh representation of this brep.</summary>
    [Newtonsoft.Json.JsonProperty( "displayValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleMesh DisplayValue { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleBrep FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleBrep>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleExtrusion : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Extrusion;

    [Newtonsoft.Json.JsonProperty( "capped", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Capped { get; set; }

    [Newtonsoft.Json.JsonProperty( "profile", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleObject Profile { get; set; }

    [Newtonsoft.Json.JsonProperty( "pathStart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePoint PathStart { get; set; }

    [Newtonsoft.Json.JsonProperty( "pathEnd", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePoint PathEnd { get; set; }

    [Newtonsoft.Json.JsonProperty( "pathCurve", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleObject PathCurve { get; set; }

    [Newtonsoft.Json.JsonProperty("pathTangent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public SpeckleObject PathTangent { get; set; }

    [Newtonsoft.Json.JsonProperty("profileTransformation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Object ProfileTransformation { get; set; }

    [Newtonsoft.Json.JsonProperty("profiles", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public List<SpeckleObject> Profiles { get; set; }
     
    [Newtonsoft.Json.JsonProperty( "length", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Length;

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleExtrusion FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleExtrusion>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleAnnotation : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Annotation;

    [Newtonsoft.Json.JsonProperty( "text", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Text { get; set; }

    [Newtonsoft.Json.JsonProperty( "textHeight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? TextHeight { get; set; }

    [Newtonsoft.Json.JsonProperty( "fontName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string FontName { get; set; }

    [Newtonsoft.Json.JsonProperty( "bold", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Bold { get; set; }

    [Newtonsoft.Json.JsonProperty( "italic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Italic { get; set; }

    [Newtonsoft.Json.JsonProperty( "location", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePoint Location { get; set; }

    [Newtonsoft.Json.JsonProperty( "plane", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpecklePlane Plane { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleAnnotation FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleAnnotation>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleBlock : SpeckleObject
  {
    [Newtonsoft.Json.JsonProperty( "type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    [Newtonsoft.Json.JsonConverter( typeof( Newtonsoft.Json.Converters.StringEnumConverter ) )]
    public SpeckleObjectType Type { get; set; } = SpeckleObjectType.Block;

    [Newtonsoft.Json.JsonProperty( "name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    [Newtonsoft.Json.JsonProperty( "description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Description { get; set; }

    [Newtonsoft.Json.JsonProperty( "objects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<SpeckleObject> Objects { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleBlock FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleBlock>( data );
    }

  }

}
