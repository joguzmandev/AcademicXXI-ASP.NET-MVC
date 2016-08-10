using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class Professor : BaseDomain
    {
        public String FullName { get; set; }
        public String DocumentID { get; set; }


        //One Professor has many Records
        public virtual List<Record> Records { get; set; }
    }
}
