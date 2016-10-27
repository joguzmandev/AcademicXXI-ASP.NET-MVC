using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class StudyPlan : BaseDomain
    {
        public StudyPlan()
        {
            StudentPlans = new List<StudentPlan>();
            Subjects = new List<Subject>();
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<StudentPlan> StudentPlans { get; set; }
    }
}
