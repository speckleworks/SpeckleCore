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

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadStreamUpdate FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadStreamUpdate>(data);
        }
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
    public partial class PayloadObjectGetWithArray
    {
        /// <summary>An array of object ids to retrieve from the database.</summary>
        [Newtonsoft.Json.JsonProperty("objects", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<string> Objects { get; set; } = new List<string>();

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PayloadObjectGetWithArray FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayloadObjectGetWithArray>(data);
        }
    }
}
