using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    [Table("LineRecordStudent")]
    public class LineRecordStudentDetails : BaseDomain
    {
        [Key, Column("StudentID"), Index("StudentID_Unique", IsUnique = false), StringLength(10)]
        public string StudentFK { get; set; }
        public Student Student { get; set; }


    }
}
