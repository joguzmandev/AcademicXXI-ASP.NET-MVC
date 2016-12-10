using System;
using AcademicXXI.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicXXI.Domain
{
    public abstract class BaseDomain
    {
        public virtual Status Status { get; set; }

        [Column(TypeName = "datetime2")]
        public virtual DateTime Created { get; set; }
    }
}
