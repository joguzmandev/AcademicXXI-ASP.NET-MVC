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

        [Key,Column("SubjectFK", Order =1),ForeignKey("Subject")]
        public string SubjectFK { get; set; }

        public virtual Subject Subject { get; set; }

        [Key,Column("SemesterFK", Order = 2), ForeignKey("Semester")]
        public String SemesterFK { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual ICollection<RecordDetails> RecordDetails { get; set; }

        public Record()
        {
            this.RecordDetails = new List<RecordDetails>();
        }
    }
}
