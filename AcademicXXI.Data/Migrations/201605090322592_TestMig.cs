namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudyPlans",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Credit = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 7),
                        PrerequisiteCode = c.String(nullable: false, maxLength: 7),
                        StudyPID = c.Guid(),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudyPlans", t => t.StudyPID)
                .Index(t => t.StudyPID);
            
            AddColumn("dbo.Students", "StudyPlanId", c => c.Guid());
            CreateIndex("dbo.Students", "StudyPlanId");
            AddForeignKey("dbo.Students", "StudyPlanId", "dbo.StudyPlans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudyPlanId", "dbo.StudyPlans");
            DropForeignKey("dbo.Subjects", "StudyPID", "dbo.StudyPlans");
            DropIndex("dbo.Subjects", new[] { "StudyPID" });
            DropIndex("dbo.Students", new[] { "StudyPlanId" });
            DropColumn("dbo.Students", "StudyPlanId");
            DropTable("dbo.Subjects");
            DropTable("dbo.StudyPlans");
        }
    }
}
