using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Document_Management_Solution.Models
{
    public class DocManagerContext : DbContext
    {
        const string ConnectionString = "DocumentManagerConnection";

        public DocManagerContext() : base(ConnectionString)
        {
            
        }

        public DbSet<DocumentModel> DocumentModels { get; set; }

       
    }
}