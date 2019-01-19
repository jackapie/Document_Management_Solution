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

        [HttpPost]
        public void UploadDocument(string DocumentTitle, string DocumentId, HttpPostedFileBase upload)
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

        }
    }
}