using Microsoft.VisualStudio.TestTools.UnitTesting;
using Document_Management_Solution.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Document_Management_Solution.Helpers.Tests
{
    [TestClass()]
    public class DbHelperTests
    {
        [TestMethod()]
        public void GetByIdTest()
        {
            var dbHelper = new DbHelper();
            var document = dbHelper.GetById(5);
            var title = document.DocumentTitle;
            Assert.AreEqual("SomeTitle5", title);
        }

        [TestMethod()]
        public void CreateDocumentTest()
        {
            var dbHelper = new DbHelper();
            var file = File.ReadAllBytes("TextFile1.txt");
            dbHelper.CreateDocument("SomeTitle6", "Document6", file, "TextFile1.txt");

            var document = dbHelper.GetDocuments("SomeTitle6", "").First();
            var fileName = document.FileName;
            Assert.AreEqual("TextFile1.txt", fileName);
            CollectionAssert.AreEqual(file, document.File);
        }
    }


}