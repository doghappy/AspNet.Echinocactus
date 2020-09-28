using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DogHappy.AspNet.Echinocactus.Tests.JsonHandlerTests
{
    [TestClass]
    public class GetFormValueTest
    {

        [TestMethod]
        public void StringEmptyTest()
        {
            var request = new HttpRequest("filename", "http://dot.net", "p1=qwr");
            var response = new HttpResponse(null);
            var httpContext = new HttpContext(request, response);
            var handler = new JsonHandler(httpContext);
            var actual = handler.GetFormValue<string>("p1");
            Assert.AreEqual(string.Empty, actual);
        }

        /*
         * ASP.NET cannot unit test the Request.Form
         */

        //[TestMethod]
        //public void StringTest()
        //{
        //    var request = new HttpRequest("filename", "http://dot.net", "p1=qwr");
        //    request.ContentType = JsonHandler.ApplicationJson;
        //    var response = new HttpResponse(null);
        //    var httpContext = new HttpContext(request, response);
        //    var handler = new JsonHandler(httpContext);
        //    var actual = handler.GetQueryStringValue<string>("query");
        //    Assert.AreEqual("Form", actual);
        //}
    }
}
