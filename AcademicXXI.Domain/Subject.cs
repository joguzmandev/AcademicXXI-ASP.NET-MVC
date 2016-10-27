using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class Subject : BaseDomain
    {
        public string Name { get; set; }
        public int Credit { get; set; }
        public string Code { get; set; }
        public string PrerequisiteCode { get; set; }

        public Int32? StudyPID { get; set; }

        public virtual StudyPlan StudyPlan { get; set; }
    }
}
