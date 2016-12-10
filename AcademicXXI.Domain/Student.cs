using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicXXI.Domain
{
    public class Student : BaseDomain
    {
        #region Property
        [Key, Column("StudentID"),Index("RegisterNumber_Unique",IsUnique = true),StringLength(10)]
        public string RegisterNumber { get; set; }
        
        [Required,Column("FirstName"),MaxLength(30)]
        public string FirstName { get; set; }
        
        [Required,Column("LastName"),MaxLength(30)]
        public string LastName { get; set; }

        [Required,Column("DocumentID"),Index("DocumentID_Unique",IsUnique =true),MaxLength(11)]
        public string DocumentID { get; set; }
        #endregion

        #region Relationship
        public virtual ICollection<StudentPlan> StudentPlans { get; set; }
        
        #endregion

        public Student()
        {
            this.StudentPlans = new List<StudentPlan>();
            
        }


    }
}
