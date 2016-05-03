using AcademicXXI.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

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
            modelBuilder.Entity<Student>().Property(x => x.DocumentID).IsRequired().HasMaxLength(11)
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("DocumentID_Unique") {
                            IsUnique =true
                        }));
            modelBuilder.Entity<Student>().Property(x => x.RegisterNumber)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("RegisterNumber_Unique") {
                            IsUnique = true
                        }));
        }
    }

    
}
