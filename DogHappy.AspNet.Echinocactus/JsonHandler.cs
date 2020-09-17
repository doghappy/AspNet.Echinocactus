using DogHappy.AspNet.Echinocactus.ValueConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Web;

namespace DogHappy.AspNet.Echinocactus
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public JsonHandler(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            else
            {
                HttpContext = context;
            }
        }

        /// <summary>
        /// application/json
        /// </summary>
        public const string ApplicationJson = "application/json";

        /// <summary>
        /// 
        /// </summary>
        public HttpContext HttpContext { get; }

        private IValueConverter GetConverter(Type type)
        {
            IValueConverter converter = null;
            switch (type)
            {
                case Type _ when type == typeof(string):
                    converter = new StringConverter();
                    break;
                case Type _ when type == typeof(short):
                    converter = new Int16Converter();
                    break;
                case Type _ when type == typeof(int):
                    converter = new Int32Converter();
                    break;
                case Type _ when type == typeof(long):
                    converter = new Int64Converter();
                    break;
                case Type _ when type == typeof(char):
                    converter = new CharConverter();
                    break;
                case Type _ when type == typeof(Guid):
                    converter = new GuidConverter();
                    break;
                case Type _ when type == typeof(DateTime):
                    converter = new DateTimeConverter();
                    break;
                case Type _ when type == typeof(DateTimeOffset):
                    converter = new DateTimeOffsetConverter();
                    break;
                case Type _ when type == typeof(float):
                    converter = new FloatConverter();
                    break;
                case Type _ when type == typeof(double):
                    converter = new DoubleConverter();
                    break;
                case Type _ when type == typeof(decimal):
                    converter = new DecimalConverter();
                    break;
            }
            return converter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T ChangeType<T>(object value)
        {
            Type type = typeof(T);
            if (type.IsArray)
            {
                Type elementType = type.GetElementType();
                IValueConverter converter = GetConverter(elementType);
                if (converter != null)
                {
                    string[] items = value.ToString().Split(',');
                    Array array = Array.CreateInstance(elementType, items.Length);
                    for (int i = 0; i < items.Length; i++)
                    {
                        var element = converter.Convert(items[i]);
                        array.SetValue(element, i);
                    }
                    return (T)(object)array;
                }
            }
            else if (type.IsGenericType)
            {
                //Type elementType = type.GenericTypeArguments[0];
                //IValueConverter converter = GetConverter(elementType);
                //if (converter != null)
                //{
                //    string[] items = value.ToString().Split(',');
                //    var collection = Activator.CreateInstance<T>();
                //    Type collectionType = collection.GetType();
                //    var method = collectionType.GetMethod("Add");
                //    if (method == null)
                //    {
                //        throw new TypeInitializationException(collectionType.FullName, new Exception("There is no Add method in the type definition."));
                //    }
                //    foreach (var item in items)
                //    {
                //        var element = converter.Convert(item);
                //        method.Invoke(collection, new[] { element });
                //    }
                //    return (T)(object)collection;
                //}
                throw new ArgumentException($"Unable to get the data of the generic class, please try using: {type.GenericTypeArguments[0].FullName}[]");
            }
            else
            {
                IValueConverter converter = GetConverter(type);
                if (converter != null)
                {
                    return (T)converter.Convert(value);
                }
            }
            return default;
        }

        /// <summary>
        /// Get data from the QueryString
        /// </summary>
        /// <typeparam name="T">char, string, short, int, long, float, double, decimal, Guid, DateTime, DateTimeOffset or array type of them</typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetQueryStringValue<T>(string key)
        {
            string value = HttpContext.Request.QueryString[key];
            return ChangeType<T>(value);
        }

        /// <summary>
        /// Get data from the form-data and x-wwww-from-urlencoded
        /// </summary>
        /// <typeparam name="T">char, string, short, int, long, float, double, decimal, Guid, DateTime, DateTimeOffset or array type of them</typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetFormValue<T>(string key)
        {
            string value = HttpContext.Request.Form[key];
            return ChangeType<T>(value);
        }

        /// <summary>
        /// Read the string from the Body(Request.InputStream) and creates an instance of the specified .NET type from the Newtonsoft.Json.Linq.JToken.
        /// </summary>
        /// <typeparam name="T">The object type that the token will be deserialized to.</typeparam>
        /// <returns></returns>
        /// <exception cref="JsonReaderException">Thrown if the string in the body is not a valid Json</exception>
        public T GetBodyValue<T>()
        {
            var obj = GetBodyValue();
            return obj.ToObject<T>();
        }

        /// <summary>
        /// Read the string from the Body(Request.InputStream) and parse it into a JSON object
        /// </summary>
        /// <returns></returns>
        /// <exception cref="JsonReaderException">Thrown if the string in the body is not a valid Json</exception>
        public JToken GetBodyValue()
        {
            using (var reader = new StreamReader(HttpContext.Request.InputStream))
            {
                string bodyStr = reader.ReadToEnd();
                return JToken.Parse(bodyStr);
            }
        }
    }
}
