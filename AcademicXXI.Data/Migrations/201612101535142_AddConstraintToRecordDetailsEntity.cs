namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraintToRecordDetailsEntity : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RecordDetails", new[] { "SubjectFK", "SemesterFK" });
            CreateIndex("dbo.RecordDetails", new[] { "SubjectFK", "SemesterFK", "NumericSession" }, unique: true, name: "IX_SubjectFKAndSemesterFKAndNumericSession");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RecordDetails", "IX_SubjectFKAndSemesterFKAndNumericSession");
            CreateIndex("dbo.RecordDetails", new[] { "SubjectFK", "SemesterFK" });
        }
    }
}
