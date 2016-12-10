namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentPlans", "StudentFK", "dbo.Students");
            DropIndex("dbo.StudentPlans", new[] { "StudentFK" });
            DropIndex("dbo.Students", "RegisterNumber_Unique");
            DropPrimaryKey("dbo.StudentPlans");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.StudentPlans", "StudentFK", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Students", "StudentID", c => c.String(nullable: false, maxLength: 10));
            AddPrimaryKey("dbo.StudentPlans", new[] { "StudentFK", "StudyPlanFK" });
            AddPrimaryKey("dbo.Students", "StudentID");
            CreateIndex("dbo.StudentPlans", "StudentFK");
            CreateIndex("dbo.Students", "StudentID", unique: true, name: "RegisterNumber_Unique");
            AddForeignKey("dbo.StudentPlans", "StudentFK", "dbo.Students", "StudentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentPlans", "StudentFK", "dbo.Students");
            DropIndex("dbo.Students", "RegisterNumber_Unique");
            DropIndex("dbo.StudentPlans", new[] { "StudentFK" });
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.StudentPlans");
            AlterColumn("dbo.Students", "StudentID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.StudentPlans", "StudentFK", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Students", "StudentID");
            AddPrimaryKey("dbo.StudentPlans", new[] { "StudentFK", "StudyPlanFK" });
            CreateIndex("dbo.Students", "StudentID", unique: true, name: "RegisterNumber_Unique");
            CreateIndex("dbo.StudentPlans", "StudentFK");
            AddForeignKey("dbo.StudentPlans", "StudentFK", "dbo.Students", "StudentID", cascadeDelete: true);
        }
    }
}
