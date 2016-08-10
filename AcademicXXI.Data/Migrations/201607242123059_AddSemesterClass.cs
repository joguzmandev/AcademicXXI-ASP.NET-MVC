namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSemesterClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SemesterCode = c.String(nullable: false, maxLength: 7),
                        Description = c.String(nullable: false, maxLength: 100),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SemesterCode, unique: true, name: "SemesterCode_Unique");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Semesters", "SemesterCode_Unique");
            DropTable("dbo.Semesters");
        }
    }
}
