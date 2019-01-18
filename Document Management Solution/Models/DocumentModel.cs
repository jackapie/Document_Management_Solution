using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Document_Management_Solution.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }
        public string DocumentId { get; set; }
        public string DocumentTitle { get; set; }
        public byte[] File {get; set;}
    }
}