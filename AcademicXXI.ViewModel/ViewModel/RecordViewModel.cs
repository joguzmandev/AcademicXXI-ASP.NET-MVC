using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class RecordViewModel : BaseDomain
    {
        public Int32 SubjectId { get; set; }
        public Int32 SemesterId{get; set;}

        [ForeignKey("SubjectId")]
        public virtual SubjectViewModel SubjectViewModel { get; set; }

        [ForeignKey("SemesterId")]
        public virtual SemesterViewModel SemesterViewModel { get; set; }

        public virtual ICollection<RecordDetailsViewModel> RecordDetailsViewModel { get; set; }

    }
}
