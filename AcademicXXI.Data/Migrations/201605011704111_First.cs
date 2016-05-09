namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        DocumentID = c.String(nullable: false, maxLength: 11),
                        RegisterNumber = c.String(nullable: false, maxLength: 10),
                        Status = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.DocumentID, unique: true, name: "DocumentID_Unique")
                .Index(t => t.RegisterNumber, unique: true, name: "RegisterNumber_Unique");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", "RegisterNumber_Unique");
            DropIndex("dbo.Students", "DocumentID_Unique");
            DropTable("dbo.Students");
        }
    }
}
