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
        [Key]
        public int Id { get; set; }

        [Required]
        [Index("IX_SubjectFKAndSemesterFKAndNumericSession", 3, IsUnique = true)]
        public int NumericSession { get; set; }

        [Required]
        [MaxLength(100)]
        public String SessionDescription { get; set; }

        [Required]
        public int LimitSession { get; set; }
        
        [Column("ProfessorFK"),ForeignKey("Professor")]
        public string ProfessorFK { get; set; }

        public virtual Professor Professor { get; set; }

        [Column("SubjectFK", Order = 1)]
        [Index("IX_SubjectFKAndSemesterFKAndNumericSession", 1,IsUnique =true)]
        public string SubjectFK { get; set; }

        [Column("SemesterFK", Order = 2)]
        [Index("IX_SubjectFKAndSemesterFKAndNumericSession", 2, IsUnique = true)]
        public String SemesterFK { get; set; }

        [ForeignKey("SubjectFK,SemesterFK")]
        public virtual Record Record { get; set; }

       
    }
}
