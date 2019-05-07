extern alias SpeckleNewtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
  /// <summary>Base class that adds a set of simple properties related to authorisation and commenting to all applicable resources (not users).</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class ResourceBase
  {
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "_id", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _id { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "owner", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Owner { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "private", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Private { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "anonymousComments", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? AnonymousComments { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "canRead", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> CanRead { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "canWrite", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> CanWrite { get; set; }

    /// <summary>An array of comment ids.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "comments", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Comments { get; set; }

    /// <summary>Controls archival status - does not actually delete anything</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "deleted", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Deleted { get; set; }

    public virtual string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static ResourceBase FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<ResourceBase>( data );
    }

  }

  /// <summary>Describes a user.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class User
  {
    /// <summary>Database uuid.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "_id", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _id { get; set; }

    /// <summary>Password.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "password", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Password { get; set; }

    /// <summary>User's role. Defaults to "user".</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "role", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Role { get; set; }

    /// <summary>We will need profile pics at one point.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "avatar", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Avatar { get; set; }

    /// <summary>a signed jwt token that expires in 1 year.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "apitoken", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Apitoken { get; set; }

    /// <summary>a signed jwt token that expires in 1 day.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "token", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Token { get; set; }

    /// <summary>user's email</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "email", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Email { get; set; }

    /// <summary>User's given name</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "name", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    /// <summary>User's family name</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "surname", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Surname { get; set; }

    /// <summary>Users's company</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "company", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Company { get; set; }

    /// <summary>an array storing each time the user logged in.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "logins", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<LoginDateProperty> Logins { get; set; }

    public string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static User FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<User>( data );
    }

  }

  /// <summary>A speckle client.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class AppClient : ResourceBase
  {
    /// <summary>Database uuid.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "_id", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _id { get; set; }

    /// <summary>Either Sender, Receiver or anything else you can think of.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "role", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Role { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "documentGuid", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string DocumentGuid { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "documentName", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string DocumentName { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "documentType", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string DocumentType { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "documentLocation", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string DocumentLocation { get; set; }

    /// <summary>The streamId that this client is attached to.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "streamId", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string StreamId { get; set; }

    /// <summary>Is it accessible from the server or not?</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "online", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Online { get; set; }

    public string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static AppClient FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<AppClient>( data );
    }

  }

  /// <summary>A project contains a group of streams and users.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class Project : ResourceBase
  {
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "_id", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _id { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "name", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "number", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string number { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "users", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Users { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "streams", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Streams { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "subProjects", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> SubProjects { get; set; }

    public string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static Project FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<Project>( data );
    }

  }

  /// <summary>A comment/issue.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class Comment : ResourceBase
  {
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "resource", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public Resource Resource { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "text", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Text { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "assignedTo", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> AssignedTo { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "closed", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Closed { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "labels", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Labels { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "view", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public object View { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "screenshot", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Screenshot { get; set; }

    public string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static Comment FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<Comment>( data );
    }

  }

  /// <summary>A stream is essentially a collection of objects, with added properties.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleStream : ResourceBase
  {
    /// <summary>The stream's short id.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "streamId", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string StreamId { get; set; }

    /// <summary>The data stream's name</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "name", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    /// <summary>The data stream's description</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "description", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Description { get; set; }

    /// <summary>The data stream's name</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "tags", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Tags { get; set; }

    /// <summary>An array of SpeckleObject ids.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "objects", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<SpeckleObject> Objects { get; set; }

    /// <summary>An array of speckle layers.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "layers", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<Layer> Layers { get; set; }

    /// <summary>Units, tolerances, etc.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "baseProperties", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public dynamic BaseProperties { get; set; }

    /// <summary>Any performance measures can go in here.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "globalMeasures", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public dynamic GlobalMeasures { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "isComputedResult", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? IsComputedResult { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "viewerLayers", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<dynamic> ViewerLayers { get; set; }

    /// <summary>If this stream is a child, the parent's streamId.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "parent", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Parent { get; set; }

    /// <summary>An array of the streamId of any children of this stream.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "children", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Children { get; set; }

    /// <summary>If resulting from a merge, the streams that this one was born out of.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "ancestors", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Ancestors { get; set; }

    public string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleStream FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleStream>( data );
    }

  }

  /// <summary>Describes a speckle layer. To assign objects to a speckle layer, you'll need to start at `objects[ layer.startIndex ]` and finish at `objects[ layer.startIndex + layer.objectCount ]`.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class Layer
  {
    /// <summary>Layer's name</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "name", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    /// <summary>Layer's guid (must be unique)</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "guid", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Guid { get; set; }

    /// <summary>Describes this layer's position in the list of layers.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "orderIndex", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public int? OrderIndex { get; set; }

    /// <summary>The index of the first object relative to the stream's objects array</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "startIndex", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? StartIndex { get; set; }

    /// <summary>How many objects does this layer have.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "objectCount", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? ObjectCount { get; set; }

    /// <summary>String describing the nested tree structure (GH centric).</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "topology", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Topology { get; set; }

    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "properties", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public LayerProperties Properties { get; set; }

    public string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static Layer FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<Layer>( data );
    }

  }

  /// <summary>Holds stream layer properties, mostly for displaying purposes. This object will be filled up with garbage from threejs and others, but below is a minimal schema.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class LayerProperties
  {
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "color", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleBaseColor Color { get; set; }

    /// <summary>toggles layer visibility.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "visible", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Visible { get; set; }

    /// <summary>defines point size in threejs</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "pointsize", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Pointsize { get; set; }

    /// <summary>defines line thickness in threejs</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "linewidth", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Linewidth { get; set; }

    /// <summary>says it all. speckle is superficial.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "shininess", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Shininess { get; set; }

    /// <summary>smooth shading toggle</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "smooth", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Smooth { get; set; }

    /// <summary>display edges or not yo.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "showEdges", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? ShowEdges { get; set; }

    /// <summary>i'm bored.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "wireframe", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Wireframe { get; set; }

    public string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static LayerProperties FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<LayerProperties>( data );
    }

  }

  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" ) ]
  [SpeckleNewtonsoft.Newtonsoft.Json.JsonConverter( typeof( SpeckleObjectConverter ), "type" )]
  public partial class SpeckleObject : ResourceBase
  {
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "type", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public virtual string Type { get; set; } = "Object";

    /// <summary>Object's unique hash.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "hash", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Hash { get; set; }

    /// <summary>Object's transform.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "transform", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<double> Transform { get; set; }

    /// <summary>Object's geometry hash</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "geometryHash", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string GeometryHash { get; set; }

    /// <summary>The id/guid that the origin application identifies this object by.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "applicationId", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string ApplicationId { get; set; }

    /// <summary>The name of this object in the origin application GUI.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "name", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    /// <summary>The extra properties field of a speckle object.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "properties", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonConverter( typeof( SpecklePropertiesConverter ) )]
    public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

    /// <summary>If this object is a child, the parent's objectid.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "parent", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Parent { get; set; }

    /// <summary>An array of the ids of any children of this object.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "children", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Children { get; set; }

    /// <summary>If resulting from a merge, the objects that this one was born out of.</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "ancestors", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Ancestors { get; set; }

    public string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleObject FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleObject>( data );
    }

    public bool Equals( SpeckleObject x, SpeckleObject y )
    {
      return x.Hash == y.Hash;
    }

    public int GetHashCode( SpeckleObject obj )
    {
      return obj.Hash.GetHashCode();
    }
  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleAbstract : SpeckleObject
  {
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "type", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get; set; } = "Abstract";

    /// <summary>the original type of the object</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "_type", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _type { get; set; }

    /// <summary>the original type of the object</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "_ref", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _ref { get; set; }

    /// <summary>the original assembly of this object</summary>
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "_assembly", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _assembly { get; set; }

    public string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleAbstract FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleAbstract>( data );
    }

  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleNull : SpeckleObject
  {
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "type", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get; set; } = "Null";

    public SpeckleNull( )
    {
      this.GeometryHash = "Null.0"; this.Hash = "Null.0";
    }
  }

  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (SpeckleNewtonsoft.Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpecklePlaceholder : SpeckleObject
  {
    [SpeckleNewtonsoft.Newtonsoft.Json.JsonProperty( "type", Required = SpeckleNewtonsoft.Newtonsoft.Json.Required.Default, NullValueHandling = SpeckleNewtonsoft.Newtonsoft.Json.NullValueHandling.Ignore )]
    public override string Type { get; set; } = "Placeholder";

    public string ToJson( )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpecklePlaceholder FromJson( string data )
    {
      return SpeckleNewtonsoft.Newtonsoft.Json.JsonConvert.DeserializeObject<SpecklePlaceholder>( data );
    }

  }

}
