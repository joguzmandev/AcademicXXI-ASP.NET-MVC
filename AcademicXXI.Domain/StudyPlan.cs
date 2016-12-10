using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class StudyPlan : BaseDomain
    {

        #region Property
        [Key,Column("StudyPlanID"),MaxLength(10)]
        public string Code { get; set; }

        [Required,MaxLength(30)]
        public string Name { get; set; }       

        #endregion

        #region Relationship
        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<StudentPlan> StudentPlans { get; set; }
        #endregion

        public StudyPlan()
        {
            StudentPlans = new List<StudentPlan>();
            Subjects = new List<Subject>();
        }
    }
}
