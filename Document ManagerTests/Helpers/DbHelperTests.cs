using Microsoft.VisualStudio.TestTools.UnitTesting;
using Document_Management_Solution.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}