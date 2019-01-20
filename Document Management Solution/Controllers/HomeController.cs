using Document_Management_Solution.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace Document_Management_Solution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DocumentUploadPage()
        {
            return View();
        }

        public ActionResult DocumentSearchPage(string DocumentTitle, string DocumentId)
        {
            var dbHelper = new DbHelper();
            var data = dbHelper.GetDocuments(DocumentTitle, DocumentId);
            return View(data);
        }

        public ActionResult DocumentSubmittedPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadDocument(string DocumentTitle, string DocumentId, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                // BinaryReader is an IDisposable, 'using' ensures disposal of reader
                using (var reader = new BinaryReader(upload.InputStream))
                {
                    var fileByteArray = reader.ReadBytes(upload.ContentLength);
                    var fileName = Path.GetFileName(upload.FileName);

                    var dbHelper = new DbHelper();

                    dbHelper.CreateDocument(DocumentTitle, DocumentId, fileByteArray, fileName);

                }
            }

            return View("DocumentSubmittedPage");

        }

        public ActionResult Download(int Id)
        {
            var dbHelper = new DbHelper();
            var document = dbHelper.GetById(Id);
            var file = new System.Net.Mime.ContentDisposition
            {
                
                FileName = document.FileName,

                // always prompt the user for downloading, set to true if you want 
                // the browser to try to show the file inline
                Inline = false,
            };

            var contentType = document.GetType().ToString();
            Response.AppendHeader("Content-Disposition", file.ToString());
            return File(document.File, contentType);
        }
    }
}