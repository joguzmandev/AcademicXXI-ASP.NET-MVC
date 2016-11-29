namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditSemesterDomain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Semesters", "Period", c => c.Int(nullable: false));
            AddColumn("dbo.Semesters", "Year", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Semesters", "Year");
            DropColumn("dbo.Semesters", "Period");
        }
    }
}
