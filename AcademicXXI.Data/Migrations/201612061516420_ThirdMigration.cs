namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "PrerequisiteCode", c => c.String(maxLength: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "PrerequisiteCode", c => c.String(nullable: false, maxLength: 7));
        }
    }
}
