using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class SpRecordStudent
    {
        public int NumericSession { get; set; }
        public string RecordDetailId { get; set; }
        public string SessionDescription { get; set; }
        public string SemesterID { get; set; }
        public string SemesterDescription { get; set; }
        public string SubjectID { get; set; }
        public string SubjecName { get; set; }
        public int SubjectCredit { get; set; }
        public string LineRecordStudentID { get; set; }
        public Nullable<int> NumericScore { get; set; }
        public string LiteralScore { get; set; }
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentID { get; set; }
        public string ProfessorID { get; set; }
        public string ProfesorName { get; set; }
    }
}