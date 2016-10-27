using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AcademicXXI.Domain
{
    public class StudentPlan
    {
        [Key]
        [Column(Order = 0)]
        public int StudentID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int StudyPlanID { get; set; }

        public DateTime Created { get; set; }

        public Student Student { get; set; }
        public StudyPlan StudyPlan { get; set; }
    }
}
