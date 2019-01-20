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

       

        public List<DocumentModel> GetDocuments(string DocumentTitle, string DocumentId)
        {
            var context = new DocManagerContext();
            IQueryable<DocumentModel> documents = context.DocumentModels;

            if (string.IsNullOrEmpty(DocumentTitle) == false)
            {
                documents = documents.Where((e) => e.DocumentTitle.Contains(DocumentTitle));
            }

            if (string.IsNullOrEmpty(DocumentId) == false)
            {
                documents = documents.Where((e) => e.DocumentId.Contains(DocumentId));
            }

            return documents.ToList();
        }


        public void CreateDocument(string DocumentTitle, string DocumentId, byte[] fileByteArray, string fileName)
        {
            var context = new DocManagerContext();
            var document = new DocumentModel
            {
                DocumentTitle = DocumentTitle,
                DocumentId = DocumentId,
                File = fileByteArray,
                FileName = fileName
            };


            context.DocumentModels.Add(document);
            context.SaveChanges();
        }


    }
}