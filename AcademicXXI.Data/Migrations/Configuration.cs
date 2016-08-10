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

            #region Set Up Semesters
            /*
            var _201501 = new Semester()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Status = Helpers.Status.Active,
                SemesterCode = "2015-1",
                Description = "Enero/Abril 2015"
            };

            var _201502 = new Semester()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Status = Helpers.Status.Active,
                SemesterCode = "2015-2",
                Description = "Mayo/Agosto 2015"
            };

            var _201503 = new Semester()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Status = Helpers.Status.Active,
                SemesterCode = "2015-3",
                Description = "Septiembre/Diciembre 2015"
            };

            context.Semesters.Add(_201501);
            context.Semesters.Add(_201502);
            context.Semesters.Add(_201503);  */
            #endregion







        }
    }
}
