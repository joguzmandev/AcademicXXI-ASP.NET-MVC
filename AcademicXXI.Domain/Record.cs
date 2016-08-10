using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class Record : BaseDomain
    {

        public Guid SubjectId { get; set; }

        public Subject Subject { get; set; }

        public Guid ProfessorId { get; set; }

        public Professor Professor { get; set; }

        public Guid SemesterId { get; set; }

        public Semester Semester { get; set; }

        public DateTime Published { get; set; }
    }
}
