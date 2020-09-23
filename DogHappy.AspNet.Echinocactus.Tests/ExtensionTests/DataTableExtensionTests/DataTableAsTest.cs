﻿using DogHappy.AspNet.Echinocactus.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace DogHappy.AspNet.Echinocactus.Tests.ExtensionTests.DataTableExtensionTests
{
    [TestClass]
    public class DataTableAsTest
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

            table.Rows.Add(row);
            var users = table.As<User>();

            Assert.AreEqual(1, users.Count);
            Assert.AreEqual(1, users[0].Id);
            Assert.AreEqual("doghappy", users[0].Name);
            Assert.AreEqual(18, users[0].Age);
            Assert.IsNull(users[0].Sex);
            Assert.IsFalse(users[0].IsDeleted);
        }
    }
}
