﻿using AcademicXXI.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AcademicXXI.Data
{
    public class AcademicXXIDataContext : DbContext
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
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RecordDetails> RecordDetails { get; set; }
        public DbSet<LineRecordStudent> LineRecordStudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            #region Entity Configuration
            modelBuilder.Configurations.Add(new SemesterMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new StudyPlanMap());
            modelBuilder.Configurations.Add(new SubjectMap());
            #endregion
            base.OnModelCreating(modelBuilder);


        }
    }

    public sealed class SemesterMap : EntityTypeConfiguration<Semester>
    {
        public SemesterMap()
        {
            HasKey(s => s.Id);
            Property(s => s.SemesterCode).IsRequired().HasMaxLength(7)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(

                    new IndexAttribute("SemesterCode_Unique")
                    {
                        IsUnique = true
                    }));
            Property(s => s.Description).IsRequired().HasMaxLength(100);
            Property(x => x.Created).HasColumnType("datetime2");
            Property(s => s.Period).IsRequired();
            Property(s => s.Year).IsRequired().HasMaxLength(4);


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
           Property(x => x.Created).HasColumnType("datetime2");


        }
    }

    public sealed class StudyPlanMap : EntityTypeConfiguration<StudyPlan>
    {
        public StudyPlanMap()
        {
            HasKey(s => s.Id);
            Property(s => s.Name).HasMaxLength(30).IsRequired();
            Property(c => c.Code).HasMaxLength(10).IsRequired();
            Property(x => x.Created).HasColumnType("datetime2");
        }
    }
    
    public sealed class SubjectMap : EntityTypeConfiguration<Subject>
    {
        public SubjectMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).HasMaxLength(100).IsRequired();
            Property(x => x.Credit);
            Property(x => x.Code).HasColumnType("nvarchar").HasMaxLength(7).IsRequired().HasColumnAnnotation(
                IndexAnnotation.AnnotationName,new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            Property(x => x.PrerequisiteCode).HasColumnType("nvarchar").HasMaxLength(7);
            HasOptional(x => x.StudyPlan).WithMany(x => x.Subjects).HasForeignKey(x => x.StudyPID);
            Property(x => x.Created).HasColumnType("datetime2");

        }
    }
    
}
