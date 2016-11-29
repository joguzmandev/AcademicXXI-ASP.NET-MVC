using AcademicXXI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class LineRecordStudent
    {
        [Key]
        [Column(Order = 1)]
        public Int32 StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [Key]
        [Column(Order =0)]
        public Int32 RecordDetailsId { get; set; }

        [ForeignKey("RecordDetailsId")]
        public RecordDetails RecordDetails { get; set; }

        [Required]
        public int? NumericScore { get; set; }

        [Required,StringLength(2)]
        public String LiteralScore { get; set; }

        public LineRecordStudentEnum StatusLineRecordStudent { get; set; }

    }
}
