using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademicXXI.Web.Models
{
  
    public class Message
    {
        public int Code { get; set; }
        public String Messages { get; set; }
        public String Class { get; set; }
        public Object list { get; set; }
        public bool Status { get; set; }

    }
}