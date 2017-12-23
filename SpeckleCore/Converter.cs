using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
    /// <summary>
    /// A basic abstract class that all Speckle converters should implement. 
    /// Provided mostly for consistency's sake.
    /// </summary>
    public abstract class Converter
    {
        public abstract IEnumerable<SpeckleObject> ToSpeckle(IEnumerable<object> _objects);
        public abstract SpeckleObject ToSpeckle(object _object);

        public abstract IEnumerable<object> ToNative(IEnumerable<SpeckleObject> _objects);
        public abstract object ToNative(SpeckleObject _object);

        public static string getBase64(object obj)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(ms, obj);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static object getObjFromString(string base64String)
        {
            if (base64String == null) return null;
            byte[] bytes = Convert.FromBase64String(base64String);
            return getObjFromBytes(bytes);
        }

        public static object getObjFromBytes(byte[] bytes)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Deserialize(ms);
            }
        }


        public static SpeckleAbstract ToAbstract(object source, int recursionDepth = 0)
        {
            SpeckleAbstract result = new SpeckleAbstract();
            result._Type = source.GetType().AssemblyQualifiedName;

            try
            {
                if (source.GetType().IsSerializable)
                    result.Base64 = Converter.getBase64(source);
            }
            catch
            {
                result.Base64 = "Object not serialisable.";
            }

            result.Properties = Converter.ObjectToDictionary(source);

            result.SetHashes(result);

            return result;
        }

        public static Dictionary<string, object> ObjectToDictionary(object source, int recursionDepth = 0)
        {
            if (source == null) return null;
            if (recursionDepth > 12) return null;

            Dictionary<string, object> dict = new Dictionary<string, object>();

            //dict["__type"] = source.GetType().AssemblyQualifiedName;

            var properties = source.GetType().GetProperties();

            foreach (var prop in properties)
            {
                //Converter.AddValueToDictionary(dict, prop.Name, prop.GetValue(source));
                try
                {
                    object value = prop.GetValue(source);

                    if (prop.GetGetMethod().IsStatic)
                        continue;

                    if (value == null)
                    {
                        dict[prop.Name] = null;
                        continue;
                    }

                    if( value is Enum)
                    {
                        dict[prop.Name] = value.ToString();
                        continue;
                    }

                    Type valueType = value.GetType();

                    if (valueType.IsPrimitive || valueType == typeof(string))
                    {
                        dict[prop.Name] = value;
                    }
                    else if (valueType.IsEnum)
                    {
                        var myList = new List<object>();

                        var i = 0;
                        foreach (object o in (System.Collections.IEnumerable)value)
                        {
                            myList.Add(ObjectToDictionary(o, recursionDepth + 1));
                            i++;
                        }
                        dict[prop.Name] = myList;
                    }
                    else
                    {
                        //dict[prop.Name] = ObjectToDictionary(value, recursionDepth + 1);
                        if (!value.GetType().AssemblyQualifiedName.Contains("System"))
                            dict[prop.Name] = Converter.ToAbstract(value, recursionDepth + 1);
                    }

                }
                catch { dict[prop.Name] = "error"; }
            }

            return dict;
        }

        private static void AddValueToDictionary(Dictionary<string, object> dict, string key, object value)
        {
            try
            {
                if (value == null)
                {
                    dict[key] = "null";
                    return;
                }

                Type valueType = value.GetType();

                if (valueType.IsPrimitive || valueType == typeof(string))
                {
                    dict[key] = value;
                    return;
                }

                if (valueType.IsEnum)
                {
                    // ?Do what
                    dict[key] = "ENUM TODODODODOD";
                    return;
                }

                dict[key] = Converter.ToAbstract(value);
            }
            catch { }
        }
    }
}
