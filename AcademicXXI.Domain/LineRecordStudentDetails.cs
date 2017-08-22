using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    [Table("LineRecordStudent")]
    public class LineRecordStudentDetails : BaseDomain
    {
        [Key, MaxLength(25), Column("LineRecordStudentID")]
        public String LineRecordStudentID { get; set; }

        [Required, ForeignKey("Student"), MaxLength(10)]
        public string StudentFK { get; set; }

        public Student Student { get; set; }

        [Required, ForeignKey("RecordDetails"), MaxLength(15)]
        public String RecordDetailsFK { get; set; }

        public RecordDetails RecordDetails { get; set; }

        public Nullable<int> NumericScore { get; set; }

        [MaxLength(2)]
        public String LiteralScore { get; set; }
    }
}