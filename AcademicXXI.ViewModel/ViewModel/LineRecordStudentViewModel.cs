using AcademicXXI.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class LineRecordStudentViewModel
    {
        [Key]
        [Column(Order = 1)]
        public Int32 StudentId { get; set; }

        [ForeignKey("StudentId")]
        public StudentViewModel StudentViewModel { get; set; }

        [Key]
        [Column(Order = 0)]
        public Int32 RecordDetailsId { get; set; }

        [ForeignKey("RecordDetailsId")]
        public RecordDetailsViewModel RecordDetailsViewModel { get; set; }

        public Nullable<int> NumericScore { get; set; }

        [StringLength(2)]
        public String LiteralScore { get; set; }
    }
}