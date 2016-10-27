namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStudyPlanToStudyPlanListInStudentEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "StudyPlanId", "dbo.StudyPlans");
            DropIndex("dbo.Students", new[] { "StudyPlanId" });
            CreateTable(
                "dbo.StudyPlanStudents",
                c => new
                    {
                        StudyPlan_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudyPlan_Id, t.Student_Id })
                .ForeignKey("dbo.StudyPlans", t => t.StudyPlan_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.StudyPlan_Id)
                .Index(t => t.Student_Id);
            
            DropColumn("dbo.Students", "StudyPlanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "StudyPlanId", c => c.Int());
            DropForeignKey("dbo.StudyPlanStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudyPlanStudents", "StudyPlan_Id", "dbo.StudyPlans");
            DropIndex("dbo.StudyPlanStudents", new[] { "Student_Id" });
            DropIndex("dbo.StudyPlanStudents", new[] { "StudyPlan_Id" });
            DropTable("dbo.StudyPlanStudents");
            CreateIndex("dbo.Students", "StudyPlanId");
            AddForeignKey("dbo.Students", "StudyPlanId", "dbo.StudyPlans", "Id");
        }
    }
}
