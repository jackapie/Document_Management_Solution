using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Document_Management_Solution.Models
{
    public class DocManagerContext : DbContext
    {
        public DbSet<DocumentModel> DocumentModels { get; set; }

       
    }
}