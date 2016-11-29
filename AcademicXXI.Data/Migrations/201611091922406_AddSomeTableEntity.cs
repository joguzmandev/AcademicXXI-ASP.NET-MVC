namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeTableEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineRecordStudents",
                c => new
                    {
                        RecordDetailsId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        NumericScore = c.Int(nullable: false),
                        LiteralScore = c.String(nullable: false, maxLength: 2),
                        StatusLineRecordStudent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecordDetailsId, t.StudentId })
                .ForeignKey("dbo.RecordDetails", t => t.RecordDetailsId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.RecordDetailsId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.RecordDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumericSession = c.Int(nullable: false),
                        SessionDescription = c.String(nullable: false, maxLength: 100),
                        LimitSession = c.Int(nullable: false),
                        ProfessorId = c.Int(),
                        RecordId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.ProfessorId)
                .ForeignKey("dbo.Records", t => t.RecordId, cascadeDelete: false)
                .Index(t => t.ProfessorId)
                .Index(t => t.RecordId);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        DocumentID = c.String(),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: false)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: false)
                .Index(t => t.SubjectId)
                .Index(t => t.SemesterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.LineRecordStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Records", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.RecordDetails", "RecordId", "dbo.Records");
            DropForeignKey("dbo.RecordDetails", "ProfessorId", "dbo.Professors");
            DropForeignKey("dbo.LineRecordStudents", "RecordDetailsId", "dbo.RecordDetails");
            DropIndex("dbo.Records", new[] { "SemesterId" });
            DropIndex("dbo.Records", new[] { "SubjectId" });
            DropIndex("dbo.RecordDetails", new[] { "RecordId" });
            DropIndex("dbo.RecordDetails", new[] { "ProfessorId" });
            DropIndex("dbo.LineRecordStudents", new[] { "StudentId" });
            DropIndex("dbo.LineRecordStudents", new[] { "RecordDetailsId" });
            DropTable("dbo.Records");
            DropTable("dbo.Professors");
            DropTable("dbo.RecordDetails");
            DropTable("dbo.LineRecordStudents");
        }
    }
}
