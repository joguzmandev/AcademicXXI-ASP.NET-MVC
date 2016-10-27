using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class Record : BaseDomain
    {

        public Int32 SubjectId { get; set; }

        public Subject Subject { get; set; }

        public Int32 ProfessorId { get; set; }

        public Professor Professor { get; set; }

        public Int32 SemesterId { get; set; }

        public Semester Semester { get; set; }

        public DateTime Published { get; set; }
    }
}
