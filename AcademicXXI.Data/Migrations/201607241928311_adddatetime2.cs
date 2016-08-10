namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.StudyPlans", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Subjects", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudyPlans", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "Created", c => c.DateTime(nullable: false));
        }
    }
}
