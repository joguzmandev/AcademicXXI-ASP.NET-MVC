using AcademicXXI.Domain;
using System.Data.Entity;


namespace AcademicXXI.Data
{
    public sealed class AcademicXXIDataContext : DbContext
    {
        public AcademicXXIDataContext() : base("AcademicXXIDataContext") { }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Set Student Table
            modelBuilder.Entity<Student>().Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Student>().Property(x => x.LastName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Student>().Property(x => x.DocumentID).IsRequired().HasMaxLength(11);
            modelBuilder.Entity<Student>().Property(x => x.RegisterNumber).IsRequired().HasMaxLength(10);


        }
    }

    
}
