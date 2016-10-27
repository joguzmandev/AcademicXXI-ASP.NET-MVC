using AcademicXXI.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class StudentViewModel : BaseDomain
    {
        public StudentViewModel()
        {
            this.StudentPlans = new List<StudentPlanViewModel>();
        }
        public ICollection<StudentPlanViewModel> StudentPlans { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Cedula")]
        public string DocumentID { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Matrícula")]
        public string RegisterNumber { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
