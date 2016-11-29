using System;
using AcademicXXI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace AcademicXXI.Domain
{
    public abstract class BaseDomain
    {
        public Int32 Id { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; set; }
    }
}
