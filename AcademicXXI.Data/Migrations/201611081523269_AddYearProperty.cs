namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYearProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Semesters", "Year", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Semesters", "Year");
        }
    }
}
