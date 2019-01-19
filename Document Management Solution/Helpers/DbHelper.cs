using Document_Management_Solution.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Document_Management_Solution.Helpers
{
    public class DbHelper
    {
        public DocumentModel GetById(int Id)
        {
            var context = new DocManagerContext();

            var document = context.DocumentModels.Where((e) => e.Id == Id).First();

            return document;
        }

        public DocumentModel GetByDocumentId(string Id)
        {
            var context = new DocManagerContext();

            var document = context.DocumentModels.Where((e) => e.DocumentId == Id).First();

            return document;
        }

        public DocumentModel GetByTitle(string Title)
        {
            var context = new DocManagerContext();
            var document = context.DocumentModels.Where((e) => e.DocumentTitle == Title).First();
            return document;
        }


        public void CreateDocument(string DocumentTitle, string DocumentId, HttpPostedFileBase upload)
        {
            var context = new DocManagerContext();
            var document = new DocumentModel
            {
                DocumentTitle = DocumentTitle,
                DocumentId = DocumentId,
                FileName = Path.GetFileName(upload.FileName)
            };

            var reader = new BinaryReader(upload.InputStream);
            document.File = reader.ReadBytes(upload.ContentLength);

            context.DocumentModels.Add(document);
            context.SaveChanges();
        }


    }
}