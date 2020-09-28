using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DogHappy.AspNet.Echinocactus.Tests.JsonHandlerTests
{
    [TestClass]
    public class GetQueryStringValueTest
    {

        [TestMethod]
        public void StringEmptyTest()
        {
            var request = new HttpRequest("filename", "http://dot.net", "p1=qwr");
            var response = new HttpResponse(null);
            var httpContext = new HttpContext(request, response);
            var handler = new JsonHandler(httpContext);
            var actual = handler.GetQueryStringValue<string>("query");
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void StringTest()
        {
            var request = new HttpRequest("filename", "http://dot.net", "p1=qwr");
            var response = new HttpResponse(null);
            var httpContext = new HttpContext(request, response);
            var handler = new JsonHandler(httpContext);
            var actual = handler.GetQueryStringValue<string>("p1");
            Assert.AreEqual("qwr", actual);
        }

        [TestMethod]
        public void CharArrayBySameKeyTest()
        {
            var request = new HttpRequest("filename", "http://dot.net", "arr=a&arr=b&&arr=c");
            var response = new HttpResponse(null);
            var httpContext = new HttpContext(request, response);
            var handler = new JsonHandler(httpContext);
            var actual = handler.GetQueryStringValue<char[]>("arr");
            Assert.AreEqual('a', actual[0]);
            Assert.AreEqual('b', actual[1]);
            Assert.AreEqual('c', actual[2]);
        }
    }
}
