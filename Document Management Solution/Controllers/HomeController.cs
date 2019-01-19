using Document_Management_Solution.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Document_Management_Solution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void UploadDocument(string DocumentTitle, string DocumentId, HttpPostedFileBase upload)
        {
            var dbHelper = new DbHelper();
            dbHelper.CreateDocument(DocumentTitle, DocumentId, upload);
        }
    }
}