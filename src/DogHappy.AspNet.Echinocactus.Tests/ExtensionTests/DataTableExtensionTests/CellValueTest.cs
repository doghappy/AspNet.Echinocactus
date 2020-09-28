using DogHappy.AspNet.Echinocactus.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace DogHappy.AspNet.Echinocactus.Tests.ExtensionTests.DataTableExtensionTests
{
    [TestClass]
    public class CellValueTest
    {
        [TestMethod]
        public void GetCellValueTest()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name");
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("Gender", typeof(bool));
            table.Columns.Add("IsDeleted", typeof(bool));
            table.Columns.Add("CreatedAt", typeof(DateTime));

            var row = table.NewRow();
            row["Id"] = 1;
            row["Name"] = "doghappy";
            row["Age"] = 18;
            row["IsDeleted"] = false;
            DateTime createdAt = DateTime.Parse("2020-09-19 10:49:27");
            row["CreatedAt"] = createdAt;

            Assert.AreEqual(1, row.GetCellValue<int>("Id"));
            Assert.AreEqual("doghappy", row.GetCellValue<string>("Name"));
            Assert.AreEqual(18, row.GetCellValue<int?>("Age").Value);
            Assert.IsFalse(row.GetCellValue<int?>("Gender").HasValue);
            Assert.IsFalse(row.GetCellValue<bool>("IsDeleted"));
            Assert.AreEqual(createdAt.ToString("yyyy-MM-dd HH:mm:ss"), row.GetCellValue<DateTime>("CreatedAt").ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
