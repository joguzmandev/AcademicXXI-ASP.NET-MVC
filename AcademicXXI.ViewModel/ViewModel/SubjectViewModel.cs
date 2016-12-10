using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class SubjectViewModel : BaseDomain
    {
        [Required]
        [StringLength(7)]
        [Display(Name = "Código Asignatura")]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Asignatura")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Creditos")]
        public int Credit { get; set; }

        [StringLength(7)]
        [Display(Name = "Prerrequisito")]
        public string PrerequisiteCode { get; set; }

        [NotMapped]
        public string FullSubjectName { get { return $"{Code} - {Name}"; } }

        
        public string StudyPlanFK { get; set; }

        [ForeignKey("StudyPlanFK")]
        public virtual StudyPlan StudyPlan { get; set; }

        public SubjectViewModel()
        {

        }
    }
}
