using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DogHappy.AspNet.Request
{
    /// <summary>
    /// InputStream 的摘要说明
    /// </summary>
    public class InputStream : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            using (var reader = new StreamReader(context.Request.InputStream))
            {
                string bodyStr = reader.ReadToEnd();
                var obj = JToken.Parse(bodyStr);
                //var aa = obj.ToObject<string[]>();
                var aa = obj.ToObject<Person>();
                context.Response.Write(bodyStr);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Test { get; set; }
    }
}