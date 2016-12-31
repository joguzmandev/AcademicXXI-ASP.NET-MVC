using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class SpStudentRecordNotesViewModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String DocumentID { get; set; }
        public String StudentID { get; set; }
        public String LiteralScore { get; set; }
        public Nullable<int> NumericScore { get; set; }
        public String SubjectName { get; set; }
        public String SubjectCode { get; set; }
        public String SemesterID { get; set; }
        public String SemesterDescription { get; set; }
        public String SemesterYear { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}