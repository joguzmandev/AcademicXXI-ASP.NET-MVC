using System;

namespace AcademicXXI.Domain
{
    public class Student : BaseDomain
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentID { get; set; }
        
        public string RegisterNumber { get; set; }


        public Guid? StudyPlanId { get; set; }
        public virtual StudyPlan StudyPlan { get; set; }


    }
}
