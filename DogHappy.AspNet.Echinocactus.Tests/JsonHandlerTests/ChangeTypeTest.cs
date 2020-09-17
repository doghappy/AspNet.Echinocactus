using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web;

namespace DogHappy.AspNet.Echinocactus.Tests.JsonHandlerTests
{
    [TestClass]
    public class ChangeTypeTest
    {
        public ChangeTypeTest()
        {
            var request = new HttpRequest("filename", "http://dot.net", "p1=qwr");
            var response = new HttpResponse(null);
            httpContext = new HttpContext(request, response);
        }

        readonly HttpContext httpContext;

        [TestMethod]
        public void StringTest()
        {
            var handler = new JsonHandler(httpContext);
            string expected = "hello world!";
            var actual = handler.ChangeType<string>(expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GuidTest()
        {
            var handler = new JsonHandler(httpContext);
            string guid = "E61ECC83-AA67-4398-87E8-2624A8D085A1";
            Guid expected = Guid.Parse(guid);
            var actual = handler.ChangeType<Guid>(guid);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Int16Test()
        {
            var handler = new JsonHandler(httpContext);
            var expected = (short)15211;
            var actual = handler.ChangeType<short>(expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Int32Test()
        {
            var handler = new JsonHandler(httpContext);
            var expected = 1567317;
            var actual = handler.ChangeType<int>(expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Int64Test()
        {
            var handler = new JsonHandler(httpContext);
            var expected = 256515438423;
            var actual = handler.ChangeType<long>(expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CharTest()
        {
            var handler = new JsonHandler(httpContext);
            var actual = handler.ChangeType<char>("[");
            Assert.AreEqual('[', actual);
        }

        [TestMethod]
        public void Char1Test()
        {
            var handler = new JsonHandler(httpContext);
            var actual = handler.ChangeType<char>("}{");
            Assert.AreEqual('}', actual);
        }

        [TestMethod]
        public void DateTimeTest()
        {
            var handler = new JsonHandler(httpContext);
            string date = "1989-6-4 20:16:20";
            DateTime expected = DateTime.Parse(date);
            var actual = handler.ChangeType<DateTime>(date);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTimeOffsetTest()
        {
            var handler = new JsonHandler(httpContext);
            string date = "1989-6-4 20:21:52";
            DateTimeOffset expected = DateTimeOffset.Parse(date);
            var actual = handler.ChangeType<DateTimeOffset>(date);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FloatTest()
        {
            var handler = new JsonHandler(httpContext);
            var expected = -1547.123f;
            var actual = handler.ChangeType<float>(expected.ToString());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleTest()
        {
            var handler = new JsonHandler(httpContext);
            var expected = -1547.12364;
            var actual = handler.ChangeType<float>(expected.ToString());
            Assert.AreEqual(expected, actual, 5);
        }

        [TestMethod]
        public void DecimalTest()
        {
            var handler = new JsonHandler(httpContext);
            var expected = -32177.2345m;
            var actual = handler.ChangeType<decimal>(expected.ToString());
            Assert.AreEqual(expected, actual);
        }
    }
}
