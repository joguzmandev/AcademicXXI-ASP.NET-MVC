using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class SubjectViewModel : BaseDomain
    {

        [Required]
        [StringLength(30)]
        [Display(Name = "Asignatura")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Creditos")]
        public int Credit { get; set; }

        [Required]
        [StringLength(7)]
        [Display(Name = "Código Asignatura")]
        public string Code { get; set; }

        [StringLength(7)]
        [Display(Name = "Prerrequisito")]
        public string PrerequisiteCode { get; set; }

        public string FullSubjectName { get { return $"{Code} - {Name}"; } }

        public Guid StudyPID { get; set; }

        public virtual StudyPlan StudyPlan { get; set; }
    }
}
