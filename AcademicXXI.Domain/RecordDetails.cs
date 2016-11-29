using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class RecordDetails : BaseDomain
    {
        [Required]
        public int NumericSession { get; set; }

        [Required]
        [MaxLength(100)]
        public String SessionDescription { get; set; }

        [Required]
        public int LimitSession { get; set; }
        
        public int? ProfessorId { get; set; }
        public Int32 RecordId { get; set; }

        [ForeignKey("ProfessorId")]
        public virtual Professor Professor { get; set; }

        [ForeignKey("RecordId")]
        public virtual Record Record { get; set; }

        public virtual ICollection<LineRecordStudent> LineRecordStudent { get; set; }

    }
}
