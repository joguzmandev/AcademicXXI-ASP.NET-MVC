using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class Professor : BaseDomain
    {
        [Key,Column("ProfessorID"), Index("DocumentID_Unique", IsUnique = true), MaxLength(11)]
        public String DocumentID { get; set; }

        public String FullName { get; set; }    

        //One Professor has many RecordDetails
        public virtual List<RecordDetails> RecordDetails { get; set; }
    }
}
