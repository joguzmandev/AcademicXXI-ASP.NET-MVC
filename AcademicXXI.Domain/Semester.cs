using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicXXI.Domain
{
    public class Semester : BaseDomain
    {
        #region Property
        [Key,MaxLength(7),Column("SemesterID")]
        public String SemesterCode { get; set; }

        [Required,MaxLength(100)]
        public String Description { get; set; }

        [Required]
        public Int32 Period { get; set; }

        [Required,MaxLength(4)]
        public String Year { get; set; }
        #endregion

        public Semester()
        {
            this.Records = new List<Record>();
        }
        public ICollection<Record> Records { get; set; }
    }
}
