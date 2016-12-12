namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ProfessorID = c.String(nullable: false, maxLength: 11),
                        FullName = c.String(),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ProfessorID)
                .Index(t => t.ProfessorID, unique: true, name: "DocumentID_Unique");
            
            CreateTable(
                "dbo.RecordDetails",
                c => new
                    {
                        SubjectFK = c.String(maxLength: 7),
                        SemesterFK = c.String(maxLength: 7),
                        RecordDetailId = c.String(nullable: false, maxLength: 128),
                        NumericSession = c.Int(nullable: false),
                        SessionDescription = c.String(nullable: false, maxLength: 100),
                        LimitSession = c.Int(nullable: false),
                        ProfessorFK = c.String(maxLength: 11),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.RecordDetailId)
                .ForeignKey("dbo.Professors", t => t.ProfessorFK)
                .ForeignKey("dbo.Records", t => new { t.SubjectFK, t.SemesterFK })
                .Index(t => new { t.SubjectFK, t.SemesterFK, t.NumericSession }, unique: true, name: "IX_SubjectFKAndSemesterFKAndNumericSession")
                .Index(t => t.ProfessorFK);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        SubjectFK = c.String(nullable: false, maxLength: 7),
                        SemesterFK = c.String(nullable: false, maxLength: 7),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.SubjectFK, t.SemesterFK })
                .ForeignKey("dbo.Semesters", t => t.SemesterFK, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectFK, cascadeDelete: true)
                .Index(t => t.SubjectFK)
                .Index(t => t.SemesterFK);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterID = c.String(nullable: false, maxLength: 7),
                        Description = c.String(nullable: false, maxLength: 100),
                        Period = c.Int(nullable: false),
                        Year = c.String(nullable: false, maxLength: 4),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.SemesterID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.String(nullable: false, maxLength: 7),
                        Name = c.String(nullable: false, maxLength: 100),
                        Credit = c.Int(nullable: false),
                        PrerequisiteCode = c.String(maxLength: 7),
                        StudyPlanFK = c.String(maxLength: 10),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.StudyPlans", t => t.StudyPlanFK)
                .Index(t => t.StudyPlanFK);
            
            CreateTable(
                "dbo.StudyPlans",
                c => new
                    {
                        StudyPlanID = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 30),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.StudyPlanID);
            
            CreateTable(
                "dbo.StudentPlans",
                c => new
                    {
                        StudentFK = c.String(nullable: false, maxLength: 10),
                        StudyPlanFK = c.String(nullable: false, maxLength: 10),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentFK, t.StudyPlanFK })
                .ForeignKey("dbo.Students", t => t.StudentFK, cascadeDelete: true)
                .ForeignKey("dbo.StudyPlans", t => t.StudyPlanFK, cascadeDelete: true)
                .Index(t => t.StudentFK)
                .Index(t => t.StudyPlanFK);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 10),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        DocumentID = c.String(nullable: false, maxLength: 11),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.StudentID)
                .Index(t => t.StudentID, unique: true, name: "RegisterNumber_Unique")
                .Index(t => t.DocumentID, unique: true, name: "DocumentID_Unique");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "SubjectFK", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "StudyPlanFK", "dbo.StudyPlans");
            DropForeignKey("dbo.StudentPlans", "StudyPlanFK", "dbo.StudyPlans");
            DropForeignKey("dbo.StudentPlans", "StudentFK", "dbo.Students");
            DropForeignKey("dbo.Records", "SemesterFK", "dbo.Semesters");
            DropForeignKey("dbo.RecordDetails", new[] { "SubjectFK", "SemesterFK" }, "dbo.Records");
            DropForeignKey("dbo.RecordDetails", "ProfessorFK", "dbo.Professors");
            DropIndex("dbo.Students", "DocumentID_Unique");
            DropIndex("dbo.Students", "RegisterNumber_Unique");
            DropIndex("dbo.StudentPlans", new[] { "StudyPlanFK" });
            DropIndex("dbo.StudentPlans", new[] { "StudentFK" });
            DropIndex("dbo.Subjects", new[] { "StudyPlanFK" });
            DropIndex("dbo.Records", new[] { "SemesterFK" });
            DropIndex("dbo.Records", new[] { "SubjectFK" });
            DropIndex("dbo.RecordDetails", new[] { "ProfessorFK" });
            DropIndex("dbo.RecordDetails", "IX_SubjectFKAndSemesterFKAndNumericSession");
            DropIndex("dbo.Professors", "DocumentID_Unique");
            DropTable("dbo.Students");
            DropTable("dbo.StudentPlans");
            DropTable("dbo.StudyPlans");
            DropTable("dbo.Subjects");
            DropTable("dbo.Semesters");
            DropTable("dbo.Records");
            DropTable("dbo.RecordDetails");
            DropTable("dbo.Professors");
        }
    }
}
