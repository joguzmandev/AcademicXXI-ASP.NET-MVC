using AcademicXXI.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AcademicXXI.Data
{
    public class AcademicXXIDataContext : DbContext
    {
        public AcademicXXIDataContext() : base("AcademicXXIDataContext")
        {
            //Disable LazyLoading
            this.Configuration.LazyLoadingEnabled = false;
            //Disable Proxy
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RecordDetails> RecordDetails { get; set; }
        //public DbSet<LineRecordStudent> LineRecordStudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }  
}
