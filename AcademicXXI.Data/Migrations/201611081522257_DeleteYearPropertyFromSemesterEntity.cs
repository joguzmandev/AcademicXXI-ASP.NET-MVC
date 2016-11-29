namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteYearPropertyFromSemesterEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Semesters", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Semesters", "Year", c => c.String(nullable: false));
        }
    }
}
