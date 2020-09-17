using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogHappy.AspNet.Request
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string query = context.Request.Form["query"];
            context.Response.Write(query);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}