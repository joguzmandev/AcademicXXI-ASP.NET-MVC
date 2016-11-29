using System;
using System.ComponentModel.DataAnnotations;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class SemesterViewModel : BaseDomain
    {
        [Required]
        [StringLength(7)]
        [Display(Name = "Código Académico")]
        public String SemesterCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descripción")]
        public String Description { get; set; }

        [Required]
        [Display(Name = "Periodo Académico")]
        public Int32 Period { get; set; }

        [Required]
        [Display(Name = "Año Académico")]
        public String Year { get; set; }
    }
}
