using AcademicXXI.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }

        public Status Status { get; set; }
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
