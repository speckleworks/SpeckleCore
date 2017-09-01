using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
    /// <summary>Describes a user.</summary>
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class User
    {
        /// <summary>Database uuid.</summary>
        [Newtonsoft.Json.JsonProperty("_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string _id { get; set; }

        /// <summary>a signed jwt token that expires in 1 year.</summary>
        [Newtonsoft.Json.JsonProperty("apitoken", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Apitoken { get; set; }

        /// <summary>user's email</summary>
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>User's given name</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>User's family name</summary>
        [Newtonsoft.Json.JsonProperty("surname", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Surname { get; set; }

        /// <summary>Users's company</summary>
        [Newtonsoft.Json.JsonProperty("company", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Company { get; set; }

        /// <summary>an array storing each time the user logged in.</summary>
        [Newtonsoft.Json.JsonProperty("logins", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<DateProperty> Logins { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static User FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<User>(data);
        }
    }

    /// <summary>A representation of the manifestation of a Speckle Client. Whenever an instance of a client is born in any software, it should get its matching identity on the server. When deserialising itself, it should call back to the database and set itself as online. Its uuid sould server as sessionId for the websocket client.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class SpeckleClient
    {
        /// <summary>Database uuid.</summary>
        [Newtonsoft.Json.JsonProperty("_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string _id { get; set; }

        /// <summary>Sender, Receiver, Mixed (for both), Parametric Sender if it can operate on parameters inside a defintion, or whatever else we can think of.</summary>
        [Newtonsoft.Json.JsonProperty("role", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Role { get; set; }

        [Newtonsoft.Json.JsonProperty("documentGuid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DocumentGuid { get; set; }

        [Newtonsoft.Json.JsonProperty("documentName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DocumentName { get; set; }

        [Newtonsoft.Json.JsonProperty("documentType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DocumentType { get; set; }

        /// <summary>The streamId that this clients 'listens to'.</summary>
        [Newtonsoft.Json.JsonProperty("streamId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StreamId { get; set; }

        [Newtonsoft.Json.JsonProperty("owner", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Owner { get; set; }

        /// <summary>Is it accessible from the server or not?</summary>
        [Newtonsoft.Json.JsonProperty("online", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Online { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleClient FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleClient>(data);
        }
    }

    /// <summary>Describes a data stream. The data stream's `streamId` will define the channel on which real-time updates will be distributed on the websocket server.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class DataStream
    {
        /// <summary>Database uuid.</summary>
        [Newtonsoft.Json.JsonProperty("_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string _id { get; set; }

        /// <summary>The stream's short id.</summary>
        [Newtonsoft.Json.JsonProperty("streamId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StreamId { get; set; }

        /// <summary>The owner's user id.</summary>
        [Newtonsoft.Json.JsonProperty("owner", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Owner { get; set; }

        [Newtonsoft.Json.JsonProperty("private", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Private { get; set; }

        /// <summary>The data stream's name</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>An array of SpeckleObject ids.</summary>
        [Newtonsoft.Json.JsonProperty("objects", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<SpeckleObjectPlaceholder> Objects { get; set; } = new List<SpeckleObjectPlaceholder>();

        /// <summary>An array of speckle layers.</summary>
        [Newtonsoft.Json.JsonProperty("layers", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<SpeckleLayer> Layers { get; set; } = new List<SpeckleLayer>();

        /// <summary>Parent stream's id, if any. If null, this is a `root` stream.</summary>
        [Newtonsoft.Json.JsonProperty("parent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Parent { get; set; }

        /// <summary>Any offspring that this stream might have (created with `/duplicate/{streamId}`</summary>
        [Newtonsoft.Json.JsonProperty("children", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<string> Children { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static DataStream FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataStream>(data);
        }
    }

    /// <summary>Describes a speckle layer. To assign objects to a speckle layer, you'll need to start at `objects[ layer.startIndex ]` and finish at `objects[ layer.startIndex + layer.objectCount ]`.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleLayer
    {
        /// <summary>Layer's name</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>Layer's guid (must be unique)</summary>
        [Newtonsoft.Json.JsonProperty("guid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Guid { get; set; }

        /// <summary>Describes this layer's position in the list of layers.</summary>
        [Newtonsoft.Json.JsonProperty("orderIndex", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OrderIndex { get; set; }

        /// <summary>The index of the first object relative to the stream's objects array</summary>
        [Newtonsoft.Json.JsonProperty("startIndex", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StartIndex { get; set; }

        /// <summary>How many objects does this layer have.</summary>
        [Newtonsoft.Json.JsonProperty("objectCount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ObjectCount { get; set; }

        /// <summary>String describing the nested tree structure (Gh centric).</summary>
        [Newtonsoft.Json.JsonProperty("topology", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Topology { get; set; }

        [Newtonsoft.Json.JsonProperty("properties", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleLayerProperties Properties { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleLayer FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleLayer>(data);
        }
    }

    /// <summary>Holds stream layer properties, mostly for displaying purposes. This object will be filled up with garbage from threejs and others, but below is a minimal schema.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleLayerProperties
    {
        [Newtonsoft.Json.JsonProperty("color", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Color Color { get; set; }

        /// <summary>toggles layer visibility.</summary>
        [Newtonsoft.Json.JsonProperty("visible", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Visible { get; set; }

        /// <summary>defines point size in threejs</summary>
        [Newtonsoft.Json.JsonProperty("pointsize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Pointsize { get; set; }

        /// <summary>defines line thickness in threejs</summary>
        [Newtonsoft.Json.JsonProperty("linewidth", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Linewidth { get; set; }

        /// <summary>says it all. speckle is superficial.</summary>
        [Newtonsoft.Json.JsonProperty("shininess", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Shininess { get; set; }

        /// <summary>smooth shading toggle</summary>
        [Newtonsoft.Json.JsonProperty("smooth", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Smooth { get; set; }

        /// <summary>display edges or not yo.</summary>
        [Newtonsoft.Json.JsonProperty("showEdges", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? ShowEdges { get; set; }

        /// <summary>i'm bored.</summary>
        [Newtonsoft.Json.JsonProperty("wireframe", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Wireframe { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleLayerProperties FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleLayerProperties>(data);
        }
    }

    /// <summary>Minimal representation of a SpeckleObject. Contains other values depending on specific class. See the .net docs for more info.</summary>
    [Newtonsoft.Json.JsonConverter(typeof(SpeckleObjectConverter), "type")]
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class SpeckleObject
    {

        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual string Type { get; set; }

        /// <summary>Object's unique hash. It's generated server-side from JSON.stringify( obj.properties ) + obj.geometryHash using a murmurhash3 128bit function.</summary>
        [Newtonsoft.Json.JsonProperty("_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DatabaseId { get; set; }

        /// <summary>Object's unique hash. It's generated server-side from JSON.stringify( obj.properties ) + obj.geometryHash using a murmurhash3 128bit function.</summary>
        [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Hash { get; set; }

        /// <summary>If the object contains 'heavy' geometry, it should have a geometry hash.</summary>
        [Newtonsoft.Json.JsonProperty("geometryHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GeometryHash { get; set; }

        /// <summary>If this object is not an ephemeral object, (ie coming from Grasshopper or Dynamo), and has a unique, persistent and consistent application id, this is where to store said guid.</summary>
        [Newtonsoft.Json.JsonProperty("applicationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ApplicationId { get; set; }

        /// <summary>Anything goes in here, including other (speckle) objects.</summary>
        [Newtonsoft.Json.JsonProperty("properties", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        /// <summary>Properties special converter.</summary>
        [JsonConverter(typeof(SpecklePropertiesConverter))]
        public Dictionary<string, object> Properties
        {
            get; set;
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleObject FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleObject>(data);
        }
    }
    
    /// <summary>
    /// Handles some error edge cases.
    /// </summary>
    /// 
    [Serializable]
    public partial class SpeckleNull : SpeckleObject
    {
        // HIC SVNT INVISIBILIA DRACONES
    }

    [Serializable]
    public partial class SpeckleObjectPlaceholder 
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual string Type { get; set; }

        /// <summary>Object's unique hash. It's generated server-side from JSON.stringify( obj.properties ) + obj.geometryHash using a murmurhash3 128bit function.</summary>
        [Newtonsoft.Json.JsonProperty("_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DatabaseId { get; set; }

        /// <summary>Object's unique hash. It's generated server-side from JSON.stringify( obj.properties ) + obj.geometryHash using a murmurhash3 128bit function.</summary>
        [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleBoolean : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Boolean";

        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Value { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleBoolean FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleBoolean>(data);
        }

        public static implicit operator bool? (SpeckleBoolean b)
        {
            return b.Value;
        }

        public static implicit operator SpeckleBoolean(bool b)
        {
            return new SpeckleBoolean() { Value = b, Type = "Boolean" };
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleNumber : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Number";

        /// <summary>A number. Can be float, double, etc.</summary>
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Value { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleNumber FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleNumber>(data);
        }

        
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleString : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "String";

        /// <summary>A string.</summary>
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleString FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleString>(data);
        }

       
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleInterval : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Interval";

        [Newtonsoft.Json.JsonProperty("start", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Start { get; set; }

        [Newtonsoft.Json.JsonProperty("end", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? End { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleInterval FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleInterval>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleInterval2d : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Interval2d";

        /// <summary>U interval.</summary>
        [Newtonsoft.Json.JsonProperty("U", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleInterval U { get; set; }

        /// <summary>V interval.</summary>
        [Newtonsoft.Json.JsonProperty("V", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleInterval V { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleInterval2d FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleInterval2d>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpecklePoint : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Point";

        /// <summary>An array containing the X, Y and Z coords of the point.</summary>
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double[] Value { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpecklePoint FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpecklePoint>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleVector : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Vector";

        /// <summary>An array containing the X, Y and Z coords of the vector.</summary>
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double[] Value { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleVector FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleVector>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpecklePlane : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        public override string Type { get; set; } = "Plane";
        /// <summary>The origin of the plane.</summary>
        [Newtonsoft.Json.JsonProperty("Origin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecklePoint Origin { get; set; }

        /// <summary>The normal of the plane.</summary>
        [Newtonsoft.Json.JsonProperty("Normal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleVector Normal { get; set; }

        /// <summary>The X axis of the plane.</summary>
        [Newtonsoft.Json.JsonProperty("Xdir", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleVector Xdir { get; set; }

        /// <summary>The Y axis of the plane.</summary>
        [Newtonsoft.Json.JsonProperty("Ydir", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleVector Ydir { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpecklePlane FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpecklePlane>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleLine : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Line";

        /// <summary>Line's start point.</summary>
        [Newtonsoft.Json.JsonProperty("start", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecklePoint Start { get; set; }

        /// <summary>Line's end point.</summary>
        [Newtonsoft.Json.JsonProperty("end", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecklePoint End { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleLine FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleLine>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleRectangle : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Rectangle";

        [Newtonsoft.Json.JsonProperty("A", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecklePoint A { get; set; }

        [Newtonsoft.Json.JsonProperty("B", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecklePoint B { get; set; }

        [Newtonsoft.Json.JsonProperty("C", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecklePoint C { get; set; }

        [Newtonsoft.Json.JsonProperty("D", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecklePoint D { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleRectangle FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleRectangle>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleCircle : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Circle";

        [Newtonsoft.Json.JsonProperty("radius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Radius { get; set; }

        [Newtonsoft.Json.JsonProperty("center", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecklePoint Center { get; set; }

        [Newtonsoft.Json.JsonProperty("normal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleVector Normal { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleCircle FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleCircle>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleBox : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Box";

        [Newtonsoft.Json.JsonProperty("basePlane", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecklePlane BasePlane { get; set; }

        [Newtonsoft.Json.JsonProperty("xSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleInterval XSize { get; set; }

        [Newtonsoft.Json.JsonProperty("ySize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleInterval YSize { get; set; }

        [Newtonsoft.Json.JsonProperty("zSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleInterval ZSize { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleBox FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleBox>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpecklePolyline : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Polyline";

        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double[] Value { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpecklePolyline FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpecklePolyline>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleCurve : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Curve";

        /// <summary>See SpeckleBrep.</summary>
        [Newtonsoft.Json.JsonProperty("base64", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Base64 { get; set; }

        /// <summary>See SpeckleBrep.</summary>
        [Newtonsoft.Json.JsonProperty("provenance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Provenance { get; set; }

        /// <summary>Contains a speckle polyline representation of this curve.</summary>
        [Newtonsoft.Json.JsonProperty("displayValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecklePolyline DisplayValue { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleCurve FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleCurve>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleMesh : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Mesh";

        /// <summary>The mesh's vertices array, in a flat array (ie, `x1, y1, z1, x2, y2, ...`)</summary>
        [Newtonsoft.Json.JsonProperty("vertices", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double[] Vertices { get; set; }

        /// <summary>The faces array.</summary>
        [Newtonsoft.Json.JsonProperty("faces", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int[] Faces { get; set; }

        /// <summary>If any, the colours per vertex.</summary>
        [Newtonsoft.Json.JsonProperty("colors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int[] Colors { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleMesh FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleMesh>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class SpeckleBrep : SpeckleObject
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public override string Type { get; set; } = "Brep";

        /// <summary>A base64 encoded string of the raw byte array of the object. Do not worry base64 encoding making strings 1.5x bigger, gzip essentially neutralises this - both in transit and in the db.</summary>
        [Newtonsoft.Json.JsonProperty("base64", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Base64 { get; set; }

        /// <summary>A short prefix of where the base64 comes from. For example, Rhino objects get ON aka Open Nurbs. Later down the road this should be a strict enum.</summary>
        [Newtonsoft.Json.JsonProperty("provenance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Provenance { get; set; }

        /// <summary>Contains a speckle mesh representation of this brep.</summary>
        [Newtonsoft.Json.JsonProperty("displayValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleMesh DisplayValue { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SpeckleBrep FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SpeckleBrep>(data);
        }
    }

    /// <summary>it's a timestamp XD</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class DateProperty
    {
        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Date { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static DateProperty FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DateProperty>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class Color
    {
        /// <summary>alpha value</summary>
        [Newtonsoft.Json.JsonProperty("a", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? A { get; set; }

        /// <summary>hex color value</summary>
        [Newtonsoft.Json.JsonProperty("hex", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Hex { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Color FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Color>(data);
        }
    }

    [Serializable]
    public partial class Client
    {
        [Newtonsoft.Json.JsonProperty("role", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Role { get; set; }

        [Newtonsoft.Json.JsonProperty("documentGuid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DocumentGuid { get; set; }

        [Newtonsoft.Json.JsonProperty("documentName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DocumentName { get; set; }

        [Newtonsoft.Json.JsonProperty("documentType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DocumentType { get; set; }

        [Newtonsoft.Json.JsonProperty("streamId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StreamId { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Client FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Client>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class Clone
    {
        /// <summary>the cloned data stream's new id.</summary>
        [Newtonsoft.Json.JsonProperty("_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string _id { get; set; }

        /// <summary>the cloned data stream's new streamId.</summary>
        [Newtonsoft.Json.JsonProperty("streamId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StreamId { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Clone FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Clone>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [Serializable]
    public partial class Parent
    {
        [Newtonsoft.Json.JsonProperty("_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string _id { get; set; }

        [Newtonsoft.Json.JsonProperty("streamId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StreamId { get; set; }

        /// <summary>the children of the original stream.</summary>
        [Newtonsoft.Json.JsonProperty("children", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<string> Children { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Parent FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Parent>(data);
        }
    }


    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.3.3.0")]
    public class SwaggerException : System.Exception
    {
        public string StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public SwaggerException(string message, string statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.3.3.0")]
    public class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, string statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }
}
