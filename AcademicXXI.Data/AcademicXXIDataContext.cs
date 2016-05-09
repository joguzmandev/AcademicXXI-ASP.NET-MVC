using AcademicXXI.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AcademicXXI.Data
{
    public sealed class AcademicXXIDataContext : DbContext
    {
        public AcademicXXIDataContext() : base("AcademicXXIDataContext") {
            //Disable LazyLoading
            this.Configuration.LazyLoadingEnabled = false;
            //Disable Proxy
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            
            #region Entity Configuration
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new StudyPlanMap());
            modelBuilder.Configurations.Add(new SubjectMap());
            #endregion
            base.OnModelCreating(modelBuilder);


        }
    }

    public sealed class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            HasKey(s => s.Id);
            Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            Property(x => x.LastName).IsRequired().HasMaxLength(30);
            Property(x => x.DocumentID).IsRequired().HasMaxLength(11).HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("DocumentID_Unique")
                        {
                            IsUnique = true
                        }));
            Property(x => x.RegisterNumber).IsRequired().HasMaxLength(10)
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("RegisterNumber_Unique")
                        {
                            IsUnique = true
                        }));
           HasOptional(x => x.StudyPlan).WithMany(x => x.Students).HasForeignKey(x => x.StudyPlanId);

        }
    }

    public sealed class StudyPlanMap : EntityTypeConfiguration<StudyPlan>
    {
        public StudyPlanMap()
        {
            HasKey(s => s.Id);
            Property(s => s.Name).HasMaxLength(30).IsRequired();
        }
    }
    
    public sealed class SubjectMap : EntityTypeConfiguration<Subject>
    {
        public SubjectMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).HasMaxLength(30).IsRequired();
            Property(x => x.Credit).IsRequired();
            Property(x => x.Code).HasColumnType("nvarchar").HasMaxLength(7).IsRequired();
            Property(x => x.PrerequisiteCode).HasColumnType("nvarchar").HasMaxLength(7).IsRequired();
            HasOptional(x => x.StudyPlan).WithMany(x => x.Subjects).HasForeignKey(x => x.StudyPID);


        }
    }
    
}
