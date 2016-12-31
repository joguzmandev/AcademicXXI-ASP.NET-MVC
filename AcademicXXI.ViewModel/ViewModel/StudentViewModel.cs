using AcademicXXI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class StudentViewModel : BaseDomain
    {
        [Required(ErrorMessage = "Campo matrícula es requerido")]
        [StringLength(10)]
        [Display(Name = "Matrícula")]
        public string RegisterNumber { get; set; }

        [Required(ErrorMessage = "Campo nombre es requerido")]
        [StringLength(30)]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Campo apellido es requerido")]
        [StringLength(30)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Campo cedula es requerido")]
        [StringLength(11)]
        [Display(Name = "Cedula")]
        public string DocumentID { get; set; }

        public ICollection<StudentPlanViewModel> StudentPlans { get; set; }
        public ICollection<LineRecordStudentViewModel> LineRecordStudentViewModel { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public StudentViewModel()
        {
            this.StudentPlans = new List<StudentPlanViewModel>();
            this.LineRecordStudentViewModel = new List<LineRecordStudentViewModel>();
        }
    }
}