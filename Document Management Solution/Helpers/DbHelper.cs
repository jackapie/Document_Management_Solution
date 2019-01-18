using Document_Management_Solution.Models;
using System;
using System.Collections.Generic;
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

        public DocumentModel GetByTitle(string Title)
        {
            var context = new DocManagerContext();
            var document = context.DocumentModels.Where((e) => e.DocumentTitle == Title).First();
            return document;
        }
    }
}