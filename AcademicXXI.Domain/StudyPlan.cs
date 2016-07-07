using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class StudyPlan : BaseDomain
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual List<Student> Students { get; set; }

        public virtual List<Subject> Subjects { get; set; }
    }
}
