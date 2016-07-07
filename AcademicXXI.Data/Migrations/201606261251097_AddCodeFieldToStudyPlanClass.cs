namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodeFieldToStudyPlanClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudyPlans", "Code", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudyPlans", "Code");
        }
    }
}
