using System;
using System.Collections.Generic;

namespace AcademicXXI.Domain
{
    public class Student : BaseDomain
    {
        public Student()
        {
            this.StudentPlans = new List<StudentPlan>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentID { get; set; }
        
        public string RegisterNumber { get; set; }


        public virtual ICollection<StudentPlan> StudentPlans { get; set; }
        public virtual ICollection<LineRecordStudent> LineRecordStudent { get; set; }




    }
}
