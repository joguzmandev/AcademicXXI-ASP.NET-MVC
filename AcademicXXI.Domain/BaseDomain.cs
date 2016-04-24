using System;
using AcademicXXI.Helpers;

namespace AcademicXXI.Domain
{
    public abstract class BaseDomain
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; set; }
    }
}
