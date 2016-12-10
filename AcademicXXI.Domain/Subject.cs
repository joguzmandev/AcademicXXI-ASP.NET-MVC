using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class Subject : BaseDomain
    {
        #region Property
        [Key,Column("SubjectID"), MaxLength(7)]
        public string Code { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Credit { get; set; }
        
        [MaxLength(7),Column(TypeName = "nvarchar")]
        public string PrerequisiteCode { get; set; }
        #endregion

        #region Relationship
        [Column("StudyPlanFK"),ForeignKey("StudyPlan")]
        public string StudyPlanFK { get; set; }

        public virtual StudyPlan StudyPlan { get; set; }
        #endregion

        public Subject()
        {

        }
    }
}
