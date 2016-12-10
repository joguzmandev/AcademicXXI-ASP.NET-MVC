using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class StudyPlanViewModel : BaseDomain
    {
        [Required]
        [StringLength(10)]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Plan de Estudio")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}
