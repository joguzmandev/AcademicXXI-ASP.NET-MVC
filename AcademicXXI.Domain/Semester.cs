using System;

namespace AcademicXXI.Domain
{
    public class Semester : BaseDomain
    {
        public String SemesterCode { get; set; }
        public String Description { get; set; }
        public Int32 Period { get; set; }
        public String Year { get; set; }
    }
}
