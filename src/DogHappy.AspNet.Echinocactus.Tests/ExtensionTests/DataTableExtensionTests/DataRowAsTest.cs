using DogHappy.AspNet.Echinocactus.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace DogHappy.AspNet.Echinocactus.Tests.ExtensionTests.DataTableExtensionTests
{
    [TestClass]
    public class DataRowAsTest
    {
        [TestMethod]
        public void AsTest()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name");
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("Gender", typeof(bool));
            table.Columns.Add("IsDeleted", typeof(bool));

            var row = table.NewRow();
            row["Id"] = 1;
            row["Name"] = "doghappy";
            row["Age"] = 18;
            row["IsDeleted"] = false;

            var user = row.As<User>();

            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("doghappy", user.Name);
            Assert.AreEqual(18, user.Age);
            Assert.IsNull(user.Sex);
            Assert.IsFalse(user.IsDeleted);
        }
    }
}
