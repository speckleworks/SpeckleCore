using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
    /// <summary>
    /// Base Speckle Object Converter.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    public class SpeckleObjectConverter : Newtonsoft.Json.JsonConverter
    {
        internal static readonly string DefaultDiscriminatorName = "discriminator";

        private readonly string _discriminator;

        [System.ThreadStatic]
        private static bool _isReading;

        [System.ThreadStatic]
        private static bool _isWriting;

        public SpeckleObjectConverter()
        {
            _discriminator = DefaultDiscriminatorName;
        }

        public SpeckleObjectConverter(string discriminator)
        {
            _discriminator = discriminator;
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            try
            {
                _isWriting = true;

                var jObject = Newtonsoft.Json.Linq.JObject.FromObject(value, serializer);

                // HACK
                //jObject.AddFirst(new Newtonsoft.Json.Linq.JProperty(_discriminator, value.GetType().Name));

                writer.WriteToken(jObject.CreateReader());
            }
            finally
            {
                _isWriting = false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                if (_isWriting)
                {
                    _isWriting = false;
                    return false;
                }
                return true;
            }
        }

        public override bool CanRead
        {
            get
            {
                if (_isReading)
                {
                    _isReading = false;
                    return false;
                }
                return true;
            }
        }

        public override bool CanConvert(System.Type objectType)
        {
            return true;
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {

            JObject jObject = null;
            jObject = serializer.Deserialize<Newtonsoft.Json.Linq.JObject>(reader);

            if (jObject == null)
                return null;

            var discriminator = Newtonsoft.Json.Linq.Extensions.Value<string>(jObject.GetValue(_discriminator));

            var subtype = GetObjectSubtypeBetter(jObject, objectType, discriminator);
            try
            {
                _isReading = true;
                return serializer.Deserialize(jObject.CreateReader(), subtype);
            }
            finally
            {
                _isReading = false;
            }
        }

        private System.Type GetObjectSubtypeBetter(Newtonsoft.Json.Linq.JObject jObject, System.Type objectType, string discriminator)
        {
            // HACK
            //if (objectType.Name == "SpeckleObject")
            discriminator = "Speckle" + discriminator;
            // ENDHACK

            var objectTypeInfo = System.Reflection.IntrospectionExtensions.GetTypeInfo(objectType);
            var customAttributes = System.Reflection.CustomAttributeExtensions.GetCustomAttributes(objectTypeInfo);

            var knownTypeAttributes = System.Linq.Enumerable.Where(customAttributes, a => a.GetType().Name == "KnownTypeAttribute");
            dynamic knownTypeAttribute = System.Linq.Enumerable.SingleOrDefault(knownTypeAttributes, a => IsKnwonTypeTargetType(a, discriminator));
            if (knownTypeAttribute != null)
                return knownTypeAttribute.Type;

            var typeName = objectType.Namespace + "." + discriminator;
            var subtype = System.Reflection.IntrospectionExtensions.GetTypeInfo(objectType).Assembly.GetType(typeName);
            if (subtype != null)
                return subtype;

            var typeInfo = jObject.GetValue("$type");
            if (typeInfo != null)
                return System.Type.GetType(Newtonsoft.Json.Linq.Extensions.Value<string>(typeInfo));

            throw new System.InvalidOperationException("Could not find subtype of '" + objectType.Name + "' with discriminator '" + discriminator + "'.");
        }

        private bool IsKnwonTypeTargetType(dynamic attribute, string discriminator)
        {
            return attribute?.Type.Name == discriminator;
        }


    }

    /// <summary>
    /// Speckle Properties mixed converter. Checks if there are any embedded Speckle Objects and casts them as appropriate.
    /// </summary>
    public class SpecklePropertiesConverter : JsonConverter
    {
        public string discriminatorName = "type";

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            this.WriteObject(writer, value);
        }

        private void WriteValue(JsonWriter writer, object value)
        {
            if (value != null)
            {
                var t = JToken.FromObject(value);
                switch (t.Type)
                {
                    case JTokenType.Object:
                        this.WriteObject(writer, value);
                        break;
                    case JTokenType.Array:
                        this.WriteArray(writer, value);
                        break;
                    default:
                        writer.WriteValue(value);
                        break;
                }
            }
            else writer.WriteValue("null");
        }

        private void WriteObject(JsonWriter writer, object value)
        {
            var obj = value as IDictionary<string, object>;
            if (obj != null)
            {
                writer.WriteStartObject();
                foreach (var kvp in obj)
                {
                    writer.WritePropertyName(kvp.Key);
                    this.WriteValue(writer, kvp.Value);
                }
                writer.WriteEndObject();
            }
            else
            {
                if (value is IntPtr)
                {
                    value = new SpeckleString(((IntPtr)value).ToString());
                    writer.WriteRawValue(((SpeckleObject)value).ToJson());
                }
                else
                    writer.WriteRawValue(((SpeckleObject)value).ToJson());
            }
        }

        private void WriteArray(JsonWriter writer, object value)
        {
            writer.WriteStartArray();
            var array = value as IEnumerable<object>;
            foreach (var o in array)
                this.WriteValue(writer, o);
            writer.WriteEndArray();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dict = new Dictionary<string, object>();

            JObject jObj = serializer.Deserialize<JObject>(reader);

            return parseObject(jObj);
        }

        private object parseObject(JObject obj)
        {
            var dict = new Dictionary<string, object>();
            bool isSpeckleObject = false;
            string type = "";

            try
            {
                var jObject = obj[discriminatorName];
                if (jObject != null)
                {
                    type = obj[discriminatorName].Value<string>();
                    isSpeckleObject = true;
                }
            }
            catch
            {
                isSpeckleObject = false;
            }

            if (!isSpeckleObject)
            {
                foreach (var sub in obj)
                    dict[sub.Key] = getValue(sub.Value);
                return dict;
            }
            else
                return JsonConvert.DeserializeObject<SpeckleObject>(JsonConvert.SerializeObject(obj));
        }

        private object getValue(JToken myToken)
        {
            switch (myToken.Type)
            {
                case JTokenType.Object:
                    var myobj = myToken.Value<JObject>();
                    return parseObject(myobj);
                case JTokenType.Boolean:
                    return myToken.ToObject(typeof(bool));
                case JTokenType.Float:
                case JTokenType.Integer:
                    return myToken.ToObject(typeof(double));
                case JTokenType.String:
                    return myToken.ToObject(typeof(string));
                case JTokenType.Array:
                    List<object> arr = (List<object>)myToken.ToObject(typeof(List<object>));
                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i] is JObject) arr[i] = parseObject(arr[i] as JObject);
                    }
                    return arr;
                default:
                    return "Problem deserialising.";
            }
        }

        public override bool CanConvert(Type objectType) { return typeof(IDictionary<string, object>).IsAssignableFrom(objectType); }
    }

    /// <summary>
    /// No clue what this robocode does.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.2.0")]
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    internal class JsonInheritanceAttribute : System.Attribute
    {
        public JsonInheritanceAttribute(string key, System.Type type)
        {
            Key = key;
            Type = type;
        }

        public string Key { get; }

        public System.Type Type { get; }
    }
}
