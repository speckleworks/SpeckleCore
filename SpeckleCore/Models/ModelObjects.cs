using Newtonsoft.Json;
using System;
using System.Collections;
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

    [System.Runtime.Serialization.EnumMember( Value = "Object" )]
    Object = 3
  }

  /// <summary>Base class that is inherited by all other Speckle objects.</summary>
  //[Newtonsoft.Json.JsonConverter( typeof( SpeckleObjectConverter ), "type" )]
  //[JsonInheritanceAttribute( "SpeckleObject", typeof( SpeckleObject ) )]
  //[JsonInheritanceAttribute( "SpeckleAbstract", typeof( SpeckleAbstract ) )]
  //[JsonInheritanceAttribute( "SpecklePlaceholder", typeof( SpecklePlaceholder ) )]
  //[JsonInheritanceAttribute( "SpeckleNull", typeof( SpeckleNull ) )]
  //[JsonInheritanceAttribute( "SpeckleBoolean", typeof( SpeckleBoolean ) )]
  //[JsonInheritanceAttribute( "SpeckleNumber", typeof( SpeckleNumber ) )]
  //[JsonInheritanceAttribute( "SpeckleString", typeof( SpeckleString ) )]
  //[JsonInheritanceAttribute( "SpeckleInterval", typeof( SpeckleInterval ) )]
  //[JsonInheritanceAttribute( "SpeckleInterval2d", typeof( SpeckleInterval2d ) )]
  //[JsonInheritanceAttribute( "SpecklePoint", typeof( SpecklePoint ) )]
  //[JsonInheritanceAttribute( "SpeckleVector", typeof( SpeckleVector ) )]
  //[JsonInheritanceAttribute( "SpecklePlane", typeof( SpecklePlane ) )]
  //[JsonInheritanceAttribute( "SpeckleCircle", typeof( SpeckleCircle ) )]
  //[JsonInheritanceAttribute( "SpeckleArc", typeof( SpeckleArc ) )]
  //[JsonInheritanceAttribute( "SpeckleEllipse", typeof( SpeckleEllipse ) )]
  //[JsonInheritanceAttribute( "SpecklePolycurve", typeof( SpecklePolycurve ) )]
  //[JsonInheritanceAttribute( "SpeckleBox", typeof( SpeckleBox ) )]
  //[JsonInheritanceAttribute( "SpecklePolyline", typeof( SpecklePolyline ) )]
  //[JsonInheritanceAttribute( "SpeckleCurve", typeof( SpeckleCurve ) )]
  //[JsonInheritanceAttribute( "SpeckleMesh", typeof( SpeckleMesh ) )]
  //[JsonInheritanceAttribute( "SpeckleBrep", typeof( SpeckleBrep ) )]
  //[JsonInheritanceAttribute( "SpeckleExtrusion", typeof( SpeckleExtrusion ) )]
  //[JsonInheritanceAttribute( "SpeckleAnnotation", typeof( SpeckleAnnotation ) )]
  //[JsonInheritanceAttribute( "SpeckleBlock", typeof( SpeckleBlock ) )]

}
