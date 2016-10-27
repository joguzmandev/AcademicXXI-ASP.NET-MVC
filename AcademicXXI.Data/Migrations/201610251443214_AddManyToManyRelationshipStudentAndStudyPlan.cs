namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToManyRelationshipStudentAndStudyPlan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudyPlanStudents", "StudyPlan_Id", "dbo.StudyPlans");
            DropForeignKey("dbo.StudyPlanStudents", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudyPlanStudents", new[] { "StudyPlan_Id" });
            DropIndex("dbo.StudyPlanStudents", new[] { "Student_Id" });
            CreateTable(
                "dbo.StudentPlans",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        StudyPlanID = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.StudyPlanID })
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.StudyPlans", t => t.StudyPlanID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.StudyPlanID);
            
            DropTable("dbo.StudyPlanStudents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudyPlanStudents",
                c => new
                    {
                        StudyPlan_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudyPlan_Id, t.Student_Id });
            
            DropForeignKey("dbo.StudentPlans", "StudyPlanID", "dbo.StudyPlans");
            DropForeignKey("dbo.StudentPlans", "StudentID", "dbo.Students");
            DropIndex("dbo.StudentPlans", new[] { "StudyPlanID" });
            DropIndex("dbo.StudentPlans", new[] { "StudentID" });
            DropTable("dbo.StudentPlans");
            CreateIndex("dbo.StudyPlanStudents", "Student_Id");
            CreateIndex("dbo.StudyPlanStudents", "StudyPlan_Id");
            AddForeignKey("dbo.StudyPlanStudents", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudyPlanStudents", "StudyPlan_Id", "dbo.StudyPlans", "Id", cascadeDelete: true);
        }
    }
}
