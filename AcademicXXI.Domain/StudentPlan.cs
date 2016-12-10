using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AcademicXXI.Domain
{
    public class StudentPlan
    {
        [Key]
        [Column("StudentFK",Order = 0),ForeignKey("Student")]
        public String StudentFK { get; set; }

        [Key]
        [Column("StudyPlanFK", Order = 1),ForeignKey("StudyPlan")]
        public string StudyPlanFK { get; set; }

        public DateTime Created { get; set; }

        public Student Student { get; set; }

        public StudyPlan StudyPlan { get; set; }
    }
}
