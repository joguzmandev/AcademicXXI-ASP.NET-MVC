using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class StudentPlanViewModel
    {
        public int StudentID { get; set; }

        public int StudyPlanID { get; set; }

        public DateTime Created { get; set; }

        public StudentViewModel Student { get; set; }

        public StudyPlanViewModel StudyPlan { get; set; }
    }
}
