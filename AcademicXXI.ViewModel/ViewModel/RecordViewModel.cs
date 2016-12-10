using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class RecordViewModel : BaseDomain
    {
        [Required]
        public string SubjectFK { get; set; }

        [Required]
        public String SemesterFK { get; set; }
        
        [ForeignKey("SubjectFK")]
        public virtual SubjectViewModel SubjectViewModel { get; set; }

        [ForeignKey("SemesterFK")]
        public virtual SemesterViewModel SemesterViewModel { get; set; }

        public virtual ICollection<RecordDetailsViewModel> RecordDetailsViewModel { get; set; }

        public RecordViewModel()
        {
            this.RecordDetailsViewModel = new List<RecordDetailsViewModel>();
        }
    }
}
