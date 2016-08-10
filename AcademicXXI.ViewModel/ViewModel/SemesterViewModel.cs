using System;
using System.ComponentModel.DataAnnotations;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class SemesterViewModel : BaseDomain
    {
        [Required]
        [StringLength(7)]
        [Display(Name = "Semestre")]
        public String SemesterCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descripción")]
        public String Description { get; set; }
    }
}
