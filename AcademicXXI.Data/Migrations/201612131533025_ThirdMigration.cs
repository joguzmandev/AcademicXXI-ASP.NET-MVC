namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineRecordStudent",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 20),
                        StudentFK = c.String(nullable: false, maxLength: 10),
                        RecordDetailsFK = c.String(nullable: false, maxLength: 15),
                        NumericScore = c.Int(nullable: false),
                        LiteralScore = c.String(nullable: false, maxLength: 2),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecordDetails", t => t.RecordDetailsFK, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentFK, cascadeDelete: true)
                .Index(t => t.StudentFK)
                .Index(t => t.RecordDetailsFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineRecordStudent", "StudentFK", "dbo.Students");
            DropForeignKey("dbo.LineRecordStudent", "RecordDetailsFK", "dbo.RecordDetails");
            DropIndex("dbo.LineRecordStudent", new[] { "RecordDetailsFK" });
            DropIndex("dbo.LineRecordStudent", new[] { "StudentFK" });
            DropTable("dbo.LineRecordStudent");
        }
    }
}
