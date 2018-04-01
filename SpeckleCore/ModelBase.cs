using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
  /// <summary>Base class that adds a set of simple properties related to authorisation and commenting to all applicable resources (not users).</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class ResourceBase
  {
    [Newtonsoft.Json.JsonProperty( "_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _id { get; set; }

    [Newtonsoft.Json.JsonProperty( "owner", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Owner { get; set; }

    [Newtonsoft.Json.JsonProperty( "private", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Private { get; set; }

    [Newtonsoft.Json.JsonProperty( "anonymousComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? AnonymousComments { get; set; }

    [Newtonsoft.Json.JsonProperty( "canRead", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> CanRead { get; set; }

    [Newtonsoft.Json.JsonProperty( "canWrite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> CanWrite { get; set; }

    /// <summary>An array of comment ids.</summary>
    [Newtonsoft.Json.JsonProperty( "comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Comments { get; set; }

    /// <summary>Controls archival status - does not actually delete anything</summary>
    [Newtonsoft.Json.JsonProperty( "deleted", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Deleted { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static ResourceBase FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<ResourceBase>( data );
    }

  }

  /// <summary>Describes a user.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class User
  {
    /// <summary>Database uuid.</summary>
    [Newtonsoft.Json.JsonProperty( "_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _id { get; set; }

    /// <summary>Password.</summary>
    [Newtonsoft.Json.JsonProperty( "password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Password { get; set; }

    /// <summary>User's role. Defaults to "user".</summary>
    [Newtonsoft.Json.JsonProperty( "role", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Role { get; set; }

    /// <summary>We will need profile pics at one point.</summary>
    [Newtonsoft.Json.JsonProperty( "avatar", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Avatar { get; set; }

    /// <summary>a signed jwt token that expires in 1 year.</summary>
    [Newtonsoft.Json.JsonProperty( "apitoken", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Apitoken { get; set; }

    /// <summary>a signed jwt token that expires in 1 day.</summary>
    [Newtonsoft.Json.JsonProperty( "token", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Token { get; set; }

    /// <summary>user's email</summary>
    [Newtonsoft.Json.JsonProperty( "email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Email { get; set; }

    /// <summary>User's given name</summary>
    [Newtonsoft.Json.JsonProperty( "name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    /// <summary>User's family name</summary>
    [Newtonsoft.Json.JsonProperty( "surname", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Surname { get; set; }

    /// <summary>Users's company</summary>
    [Newtonsoft.Json.JsonProperty( "company", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Company { get; set; }

    /// <summary>an array storing each time the user logged in.</summary>
    [Newtonsoft.Json.JsonProperty( "logins", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<LoginDateProperty> Logins { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static User FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<User>( data );
    }

  }

  /// <summary>A speckle client.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class AppClient : ResourceBase
  {
    /// <summary>Database uuid.</summary>
    [Newtonsoft.Json.JsonProperty( "_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _id { get; set; }

    /// <summary>Either Sender, Receiver or anything else you can think of.</summary>
    [Newtonsoft.Json.JsonProperty( "role", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Role { get; set; }

    [Newtonsoft.Json.JsonProperty( "documentGuid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string DocumentGuid { get; set; }

    [Newtonsoft.Json.JsonProperty( "documentName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string DocumentName { get; set; }

    [Newtonsoft.Json.JsonProperty( "documentType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string DocumentType { get; set; }

    [Newtonsoft.Json.JsonProperty( "documentLocation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string DocumentLocation { get; set; }

    /// <summary>The streamId that this client is attached to.</summary>
    [Newtonsoft.Json.JsonProperty( "streamId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string StreamId { get; set; }

    /// <summary>Is it accessible from the server or not?</summary>
    [Newtonsoft.Json.JsonProperty( "online", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Online { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static AppClient FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<AppClient>( data );
    }

  }

  /// <summary>A project contains a group of streams and users.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class Project : ResourceBase
  {
    [Newtonsoft.Json.JsonProperty( "_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string _id { get; set; }

    [Newtonsoft.Json.JsonProperty( "name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    [Newtonsoft.Json.JsonProperty( "users", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Users { get; set; }

    [Newtonsoft.Json.JsonProperty( "streams", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Streams { get; set; }

    [Newtonsoft.Json.JsonProperty( "subProjects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> SubProjects { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static Project FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<Project>( data );
    }

  }

  /// <summary>A comment/issue.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class Comment : ResourceBase
  {
    [Newtonsoft.Json.JsonProperty( "resource", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public Resource Resource { get; set; }

    [Newtonsoft.Json.JsonProperty( "text", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Text { get; set; }

    [Newtonsoft.Json.JsonProperty( "assignedTo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> AssignedTo { get; set; }

    [Newtonsoft.Json.JsonProperty( "closed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Closed { get; set; }

    [Newtonsoft.Json.JsonProperty( "labels", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Labels { get; set; }

    [Newtonsoft.Json.JsonProperty( "view", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public object View { get; set; }

    [Newtonsoft.Json.JsonProperty( "screenshot", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Screenshot { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static Comment FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<Comment>( data );
    }

  }

  /// <summary>A stream is essentially a collection of objects, with added properties.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class SpeckleStream : ResourceBase
  {
    /// <summary>The stream's short id.</summary>
    [Newtonsoft.Json.JsonProperty( "streamId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string StreamId { get; set; }

    /// <summary>The data stream's name</summary>
    [Newtonsoft.Json.JsonProperty( "name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    /// <summary>An array of SpeckleObject ids.</summary>
    [Newtonsoft.Json.JsonProperty( "objects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<SpeckleObject> Objects { get; set; }

    /// <summary>An array of speckle layers.</summary>
    [Newtonsoft.Json.JsonProperty( "layers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<Layer> Layers { get; set; }

    /// <summary>Units, tolerances, etc.</summary>
    [Newtonsoft.Json.JsonProperty( "baseProperties", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public object BaseProperties { get; set; }

    /// <summary>Any performance measures can go in here.</summary>
    [Newtonsoft.Json.JsonProperty( "globalMeasures", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public object GlobalMeasures { get; set; }

    [Newtonsoft.Json.JsonProperty( "isComputedResult", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? IsComputedResult { get; set; }

    [Newtonsoft.Json.JsonProperty( "viewerLayers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<object> ViewerLayers { get; set; }

    /// <summary>If this stream is a child, the parent's streamId.</summary>
    [Newtonsoft.Json.JsonProperty( "parent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Parent { get; set; }

    /// <summary>An array of the streamId of any children of this stream.</summary>
    [Newtonsoft.Json.JsonProperty( "children", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Children { get; set; }

    /// <summary>If resulting from a merge, the streams that this one was born out of.</summary>
    [Newtonsoft.Json.JsonProperty( "ancestors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public List<string> Ancestors { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static SpeckleStream FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleStream>( data );
    }

  }

  /// <summary>Describes a speckle layer. To assign objects to a speckle layer, you'll need to start at `objects[ layer.startIndex ]` and finish at `objects[ layer.startIndex + layer.objectCount ]`.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class Layer
  {
    /// <summary>Layer's name</summary>
    [Newtonsoft.Json.JsonProperty( "name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Name { get; set; }

    /// <summary>Layer's guid (must be unique)</summary>
    [Newtonsoft.Json.JsonProperty( "guid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Guid { get; set; }

    /// <summary>Describes this layer's position in the list of layers.</summary>
    [Newtonsoft.Json.JsonProperty( "orderIndex", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public int? OrderIndex { get; set; }

    /// <summary>The index of the first object relative to the stream's objects array</summary>
    [Newtonsoft.Json.JsonProperty( "startIndex", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? StartIndex { get; set; }

    /// <summary>How many objects does this layer have.</summary>
    [Newtonsoft.Json.JsonProperty( "objectCount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? ObjectCount { get; set; }

    /// <summary>String describing the nested tree structure (GH centric).</summary>
    [Newtonsoft.Json.JsonProperty( "topology", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public string Topology { get; set; }

    [Newtonsoft.Json.JsonProperty( "properties", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public LayerProperties Properties { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static Layer FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<Layer>( data );
    }

  }

  /// <summary>Holds stream layer properties, mostly for displaying purposes. This object will be filled up with garbage from threejs and others, but below is a minimal schema.</summary>
  [System.CodeDom.Compiler.GeneratedCode( "NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)" )]
  [Serializable]
  public partial class LayerProperties
  {
    [Newtonsoft.Json.JsonProperty( "color", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public SpeckleBaseColor Color { get; set; }

    /// <summary>toggles layer visibility.</summary>
    [Newtonsoft.Json.JsonProperty( "visible", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Visible { get; set; }

    /// <summary>defines point size in threejs</summary>
    [Newtonsoft.Json.JsonProperty( "pointsize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Pointsize { get; set; }

    /// <summary>defines line thickness in threejs</summary>
    [Newtonsoft.Json.JsonProperty( "linewidth", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Linewidth { get; set; }

    /// <summary>says it all. speckle is superficial.</summary>
    [Newtonsoft.Json.JsonProperty( "shininess", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public double? Shininess { get; set; }

    /// <summary>smooth shading toggle</summary>
    [Newtonsoft.Json.JsonProperty( "smooth", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Smooth { get; set; }

    /// <summary>display edges or not yo.</summary>
    [Newtonsoft.Json.JsonProperty( "showEdges", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? ShowEdges { get; set; }

    /// <summary>i'm bored.</summary>
    [Newtonsoft.Json.JsonProperty( "wireframe", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore )]
    public bool? Wireframe { get; set; }

    public string ToJson( )
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject( this );
    }

    public static LayerProperties FromJson( string data )
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<LayerProperties>( data );
    }

  }
}
