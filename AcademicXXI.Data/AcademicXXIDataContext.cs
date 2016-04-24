using AcademicXXI.Domain;
using System.Data.Entity;

namespace AcademicXXI.Data
{
    public class AcademicXXIDataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
