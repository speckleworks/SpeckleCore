using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
    /// <summary>User registration payload.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadAccountRegister
    {
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("surname", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Surname { get; set; }

        [Newtonsoft.Json.JsonProperty("company", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Company { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadAccountRegister FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadAccountRegister>(data);
        }
    }

    /// <summary>User login payload.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadAccountLogin
    {
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadAccountLogin FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadAccountLogin>(data);
        }
    }

    /// <summary>User login payload.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadAccountUpdate
    {
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("surname", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Surname { get; set; }

        [Newtonsoft.Json.JsonProperty("company", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Company { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadAccountUpdate FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadAccountUpdate>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadClientCreate
    {
        [Newtonsoft.Json.JsonProperty("client", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleClient Client { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadClientCreate FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadClientCreate>(data);
        }
    }

    /// <summary>model payload for Client update.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadClientUpdate
    {
        [Newtonsoft.Json.JsonProperty("client", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleClient Client { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadClientUpdate FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadClientUpdate>(data);
        }
    }

    /// <summary>model payload for stream update.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadStreamUpdate
    {
        [Newtonsoft.Json.JsonProperty("objects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<SpeckleObject> Objects { get; set; }

        [Newtonsoft.Json.JsonProperty("layers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<SpeckleLayer> Layers { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("baseProperties", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Dictionary<string, object> BaseProperties { get; set; }

        [Newtonsoft.Json.JsonProperty("globalMeasures", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<ISpeckleControllerParam> GlobalMeasures { get; set; }

        [Newtonsoft.Json.JsonProperty("private", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Private { get; set; } = false;

        [Newtonsoft.Json.JsonProperty("isComputedResult", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsComputed { get; set; } = false;

        [Newtonsoft.Json.JsonProperty("parent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Parent { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadStreamUpdate FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadStreamUpdate>(data);
        }
    }

    public partial class PayloadStreamCreate : PayloadStreamUpdate
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadStreamMetaUpdate
    {
        [Newtonsoft.Json.JsonProperty("layers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<SpeckleLayer> Layers { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadStreamMetaUpdate FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadStreamMetaUpdate>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadStreamLayersUpdate
    {
        [Newtonsoft.Json.JsonProperty("layers", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<SpeckleLayer> Layers { get; set; } = new List<SpeckleLayer>();

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadStreamLayersUpdate FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadStreamLayersUpdate>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadStreamNameUpdate
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadStreamNameUpdate FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadStreamNameUpdate>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadCreateObject
    {
        [Newtonsoft.Json.JsonProperty("object", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleObject Object { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadCreateObject FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadCreateObject>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadObjectUpdate
    {
        [Newtonsoft.Json.JsonProperty("object", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleObject Object { get; set; } = new SpeckleObject();

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadObjectUpdate FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadObjectUpdate>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadObjectCreateWithArray
    {
        [Newtonsoft.Json.JsonProperty("objects", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<SpeckleObject> Objects { get; set; } = new List<SpeckleObject>();

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadObjectCreateWithArray FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadObjectCreateWithArray>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public partial class PayloadObjectGetBulk
    {
        /// <summary>An array of object ids to retrieve from the database.</summary>
        [Newtonsoft.Json.JsonProperty("objects", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<string> Objects { get; set; } = new List<string>();

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadObjectGetBulk FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadObjectGetBulk>(data);
        }
    }

    public partial class PayloadMultipleLayers
    {
        [Newtonsoft.Json.JsonProperty("layers", Required = Newtonsoft.Json.Required.Always)]
        public IEnumerable<SpeckleLayer> Layers { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadMultipleLayers FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadMultipleLayers>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.6.3.0")]
    public partial class PayloadSingleLayer
    {
        [Newtonsoft.Json.JsonProperty("layer", Required = Newtonsoft.Json.Required.Always)]
        public SpeckleLayer Layer { get; set; } = new SpeckleLayer();

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadSingleLayer FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadSingleLayer>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.6.3.0")]
    public partial class PayloadMultipleObjects
    {
        [Newtonsoft.Json.JsonProperty("objects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<SpeckleObject> Objects { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadMultipleObjects FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadMultipleObjects>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.6.3.0")]
    public partial class PayloadMultipleObjectIds
    {
        /// <summary>An array of objectIds to remove. Must be part of the layer's subset. Or else.</summary>
        [Newtonsoft.Json.JsonProperty("objects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<string> Objects { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadMultipleObjectIds FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadMultipleObjectIds>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.6.3.0")]
    public partial class PayloadSingleObject
    {
        [Newtonsoft.Json.JsonProperty("object", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpeckleObject Object { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadSingleObject FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadSingleObject>(data);
        }
    }

}
