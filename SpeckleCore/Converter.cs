using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

        public static string bytesToBase64(byte[] arr)
        {
            return Convert.ToBase64String(arr);
        }

        public static byte[] base64ToBytes(string str)
        {
            return Convert.FromBase64String(str);
        }

        // https://stackoverflow.com/a/299526/3446736
        public static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly, Type extendedType, string methodName)
        {
            var query = from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static
                          | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == extendedType
                        where method.Name == methodName
                        select method;
            return query;
        }

        /// <summary>
        /// Will look for an extension method called "ToSpeckle" for this object type in all loaded assemblies (named "Speckle*Converter*"). If found, it will invoke it and return the SpeckleObject. If it can't find it, returns null.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static SpeckleObject TryGetSpeckleObject(object o)
        {
            List<Assembly> myAss = System.AppDomain.CurrentDomain.GetAssemblies().ToList().FindAll(s => s.FullName.Contains("Speckle") && s.FullName.Contains("Converter"));
            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (var ass in myAss)
                methods.AddRange(Converter.GetExtensionMethods(ass, o.GetType(), "ToSpeckle"));

            if (methods.Count == 0)
                return null;

            if (methods.Count >= 1)
                System.Diagnostics.Debug.WriteLine("More ToSpeckle methods found for the same object.");

            var result = methods[0].Invoke(o, new object[] { o });
            if (result != null)
                return result as SpeckleObject;

            return null;
        }

        public static object TryGetNative(SpeckleObject o)
        {
            List<Assembly> myAss = System.AppDomain.CurrentDomain.GetAssemblies().ToList().FindAll(s => s.FullName.Contains("Speckle") && s.FullName.Contains("Converter"));
            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (var ass in myAss)
                methods.AddRange(Converter.GetExtensionMethods(ass, o.GetType(), "ToNative"));

            if (methods.Count == 0)
                return null;

            if (methods.Count >= 1)
                System.Diagnostics.Debug.WriteLine("More ToNative methods found for the same object.");

            var result = methods[0].Invoke(o, new object[] { o });
            if (result != null)
                return result;

            return o;
        }

        /// <summary>
        /// Tries to cast an object back to its native type if the assembly it belongs to is present.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object FromAbstract(SpeckleAbstract obj)
        {
            var assembly = System.AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == obj._Assembly);

            if (assembly == null) // we can't deserialise for sure
                return obj;

            var type = assembly.GetTypes().FirstOrDefault(t => t.Name == obj._Type);
            if (type == null) // something wrong in the type
                return obj;

            object myObject = null;
            try
            {
                myObject = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                myObject = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(type);
            }

            foreach (string key in obj.Properties.Keys)
            {
                var prop = type.GetProperty(key);

                if (prop == null) continue;

                if (obj.Properties[key] == null) continue;

                var value = ReadValue(obj.Properties[key]);

                // handles both hashsets and lists or whatevers
                if (value is IEnumerable<object>)
                {
                    var mySubList = Activator.CreateInstance(prop.PropertyType);
                    foreach (var myObj in ((IEnumerable<object>)value))
                        mySubList.GetType().GetMethod("Add").Invoke(mySubList, new object[] { myObj });

                    value = mySubList;
                }

                prop.SetValue(myObject, value);
            }

            return myObject;
        }


        public static object ReadValue(object myObject)
        {
            if (myObject == null) return null;

            if (myObject.GetType().IsPrimitive || myObject.GetType() == typeof(string))
                return myObject;

            if (myObject is SpeckleAbstract)
                return Converter.FromAbstract((SpeckleAbstract)myObject);

            if (myObject is SpeckleObject)
                return Converter.TryGetNative((SpeckleObject)myObject);


            if (myObject is IEnumerable<object>)
                return ((IEnumerable<object>)myObject).Select(o => ReadValue(o));

            if (myObject is IDictionary<string, object>)
                return ((IDictionary<string, object>)myObject).Select(kvp => new KeyValuePair<string, object>(kvp.Key, ReadValue(kvp.Value))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return null;
        }

        /// <summary>
        /// Casts a POCO to a SpeckleAbstract object.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="recursionDepth"></param>
        /// <returns></returns>
        public static SpeckleObject ToAbstract(object source, int recursionDepth = 0, Dictionary<int, string> traversed = null, string path = "")
        {
            if (traversed == null) traversed = new Dictionary<int, string>();

            if (traversed.ContainsKey(source.GetHashCode()))
                return new SpeckleAbstract() { _Type = "ref", _Ref = traversed[source.GetHashCode()] }; // todo: add reference to field yo!
            else
                traversed.Add(source.GetHashCode(), path);

            var spk = Converter.TryGetSpeckleObject(source);
            if (spk != null) return spk;

            SpeckleAbstract result = new SpeckleAbstract();
            result._Type = source.GetType().Name;
            result._Assembly = source.GetType().Assembly.FullName;

            result.Properties = Converter.ObjectToDictionary(source, recursionDepth, traversed, path == "" ? "root/" : path);
            result.SetHashes(result);

            return result;
        }

        public static Dictionary<string, object> ObjectToDictionary(object source, int recursionDepth = 0, Dictionary<int, string> traversed = null, string path = "")
        {
            if (source == null) return null;
            if (recursionDepth > 4) return null;

            Dictionary<string, object> dict = new Dictionary<string, object>();

            var properties = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in properties)
            {
                try
                {
                    object value = prop.GetValue(source);

                    // null check
                    if (value == null)
                    {
                        dict[prop.Name] = null;
                        continue;
                    }

                    // enum
                    if (value is Enum)
                    {
                        dict[prop.Name] = ((int)value);
                        continue;
                    }

                    // primitives
                    Type valueType = value.GetType();
                    if ((valueType.IsPrimitive || valueType == typeof(string)) && (valueType != typeof(IntPtr) || valueType != typeof(UIntPtr)))
                    {
                        dict[prop.Name] = value;
                        continue;
                    }

                    // dictionaries
                    if (value is IDictionary<string, object>)
                    {
                        var vDict = value as Dictionary<string, object>;
                        if (vDict == null) continue;
                        var nDict = new Dictionary<string, object>();
                        foreach (string key in vDict.Keys)
                        {
                            if (vDict[key] != null)
                            {
                                if (vDict[key].GetType().IsPrimitive || vDict[key].GetType() == typeof(string))
                                    nDict.Add(key, vDict[key]);
                                else
                                    nDict.Add(key, Converter.ToAbstract(vDict[key], recursionDepth + 1, traversed, path + "/" + prop.Name + "[" + key + "]"));
                            }
                        }
                        dict[prop.Name] = nDict;
                        continue;
                    }

                    // lists
                    if (value is IEnumerable<object>)
                    {
                        var myList = new List<object>();
                        int i = 0;
                        foreach (object o in (System.Collections.IEnumerable)value)
                        {
                            if (o != null)
                            {
                                if (o.GetType().IsPrimitive || o.GetType() == typeof(string))
                                    myList.Add(o);
                                else
                                    myList.Add(Converter.ToAbstract(o, recursionDepth + 1, traversed, path + "/" + prop.Name + "[" + i + "]"));
                            }
                            i++;
                        }
                        dict[prop.Name] = myList;
                        continue;
                    }

                    // other objects
                    if (!value.GetType().AssemblyQualifiedName.Contains("System"))
                    {
                        dict[prop.Name] = Converter.ToAbstract(value, recursionDepth + 1, traversed, path + "/" + prop.Name);
                        continue;
                    }


                }
                catch (Exception e) { dict[prop.Name] = "Error: " + e.Message; }
            }

            return dict;
        }
    }
}
