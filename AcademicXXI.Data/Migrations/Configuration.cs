namespace AcademicXXI.Data.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AcademicXXI.Data.AcademicXXIDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AcademicXXI.Data.AcademicXXIDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var student1 = new Student()
            {
                Id = Guid.NewGuid(),
                FirstName = "Jorge Luis",
                LastName = "Guzman S.",
                DocumentID = "00118632728",
                RegisterNumber = "2014-3825",
                Created = DateTime.Now,
                Status = Helpers.Status.Active,

            };
            var student2 = new Student()
            {
                Id = Guid.NewGuid(),
                FirstName = "Jean Carlos",
                LastName = "Guzman V.",
                DocumentID = "014785293",
                RegisterNumber = "2022-3825",
                Created = DateTime.Now,
                Status = Helpers.Status.Active,

            };

            /*context.Students.Add(student1);
            context.Students.Add(student2);*/


            //Set up StudyPlay
            var studyPlan = new StudyPlan()
            {
                Id = Guid.NewGuid(),
                Name = "Cocurriculares",
                Created = DateTime.Now,
                Status = Helpers.Status.Active,

            };
            //context.StudyPlans.Add(studyPlan);

          
            

        }
    }
}
