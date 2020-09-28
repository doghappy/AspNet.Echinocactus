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
        public JsonHandler() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public JsonHandler(HttpContext context)
        {
            HttpContext = context;
        }

        /// <summary>
        /// application/json
        /// </summary>
        public const string ApplicationJson = "application/json";

        /// <summary>
        /// 
        /// </summary>
        public HttpContext HttpContext { get; set; }

        /// <summary>
        /// Get data from the QueryString
        /// </summary>
        /// <typeparam name="T">char, string, short, int, long, float, double, decimal, Guid, DateTime, DateTimeOffset or array type of them</typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetQueryStringValue<T>(string key)
        {
            string value = HttpContext.Request.QueryString[key];
            return ValueConverter.As<T>(value);
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
            return ValueConverter.As<T>(value);
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
