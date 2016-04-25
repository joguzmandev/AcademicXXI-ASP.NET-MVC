using AcademicXXI.Domain;
using System.Data.Entity;


namespace AcademicXXI.Data
{
    public sealed class AcademicXXIDataContext : DbContext
    {
        public AcademicXXIDataContext() : base("AcademicXXIDataContext") { }
        public DbSet<Student> Students { get; set; }
    }

    
}
