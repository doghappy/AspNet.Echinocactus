using DogHappy.AspNet.Echinocactus.ValueConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DogHappy.AspNet.Echinocactus.Tests
{
    [TestClass]
    public class ValueConverterTest
    {
        [TestMethod]
        public void StringTest()
        {
            string expected = "hello world!";
            var actual = ValueConverter.As<string>(expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GuidTest()
        {
            string guid = "E61ECC83-AA67-4398-87E8-2624A8D085A1";
            Guid expected = Guid.Parse(guid);
            var actual = ValueConverter.As<Guid>(guid);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Int16Test()
        {
            var expected = (short)15211;
            var actual = ValueConverter.As<short>(expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Int32Test()
        {
            var expected = 1567317;
            var actual = ValueConverter.As<int>(expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Int64Test()
        {
            var expected = 256515438423;
            var actual = ValueConverter.As<long>(expected);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CharTest()
        {
            var actual = ValueConverter.As<char>("[");
            Assert.AreEqual('[', actual);
        }

        [TestMethod]
        public void Char1Test()
        {
            var actual = ValueConverter.As<char>("}{");
            Assert.AreEqual('}', actual);
        }

        [TestMethod]
        public void DateTimeTest()
        {
            string date = "1989-6-4 20:16:20";
            DateTime expected = DateTime.Parse(date);
            var actual = ValueConverter.As<DateTime>(date);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTimeOffsetTest()
        {
            string date = "1989-6-4 20:21:52";
            DateTimeOffset expected = DateTimeOffset.Parse(date);
            var actual = ValueConverter.As<DateTimeOffset>(date);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FloatTest()
        {
            var expected = -1547.123f;
            var actual = ValueConverter.As<float>(expected.ToString());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleTest()
        {
            var expected = -1547.12364;
            var actual = ValueConverter.As<float>(expected.ToString());
            Assert.AreEqual(expected, actual, 5);
        }

        [TestMethod]
        public void DecimalTest()
        {
            var expected = -32177.2345m;
            var actual = ValueConverter.As<decimal>(expected.ToString());
            Assert.AreEqual(expected, actual);
        }
    }
}
