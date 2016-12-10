using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class StudentPlanViewModel
    {
        public string StudentID { get; set; }

        public string StudyPlanID { get; set; }

        public DateTime Created { get; set; }

        public StudentViewModel Student { get; set; }

        public StudyPlanViewModel StudyPlan { get; set; }
    }
}
