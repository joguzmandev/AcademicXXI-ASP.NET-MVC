namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SemesterCode = c.String(nullable: false, maxLength: 7),
                        Description = c.String(nullable: false, maxLength: 100),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SemesterCode, unique: true, name: "SemesterCode_Unique");
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        DocumentID = c.String(nullable: false, maxLength: 11),
                        RegisterNumber = c.String(nullable: false, maxLength: 10),
                        StudyPlanId = c.Int(),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudyPlans", t => t.StudyPlanId)
                .Index(t => t.DocumentID, unique: true, name: "DocumentID_Unique")
                .Index(t => t.RegisterNumber, unique: true, name: "RegisterNumber_Unique")
                .Index(t => t.StudyPlanId);
            
            CreateTable(
                "dbo.StudyPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Code = c.String(nullable: false, maxLength: 10),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Credit = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 7),
                        PrerequisiteCode = c.String(maxLength: 7),
                        StudyPID = c.Int(),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudyPlans", t => t.StudyPID)
                .Index(t => t.Code, unique: true)
                .Index(t => t.StudyPID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudyPlanId", "dbo.StudyPlans");
            DropForeignKey("dbo.Subjects", "StudyPID", "dbo.StudyPlans");
            DropIndex("dbo.Subjects", new[] { "StudyPID" });
            DropIndex("dbo.Subjects", new[] { "Code" });
            DropIndex("dbo.Students", new[] { "StudyPlanId" });
            DropIndex("dbo.Students", "RegisterNumber_Unique");
            DropIndex("dbo.Students", "DocumentID_Unique");
            DropIndex("dbo.Semesters", "SemesterCode_Unique");
            DropTable("dbo.Subjects");
            DropTable("dbo.StudyPlans");
            DropTable("dbo.Students");
            DropTable("dbo.Semesters");
        }
    }
}
