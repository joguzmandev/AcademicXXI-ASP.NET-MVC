using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class Record : BaseDomain
    {
        public Int32 SubjectId { get; set; }
        public Int32 SemesterId{get; set;}

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        public virtual ICollection<RecordDetails> RecordDetails { get; set; }

    }
}
