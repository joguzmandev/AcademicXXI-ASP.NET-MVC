namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RecordDetails");
            AlterColumn("dbo.RecordDetails", "Id", c => c.String(nullable: false, maxLength: 15));
            AddPrimaryKey("dbo.RecordDetails", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RecordDetails");
            AlterColumn("dbo.RecordDetails", "Id", c => c.String(nullable: false, maxLength: 10));
            AddPrimaryKey("dbo.RecordDetails", "Id");
        }
    }
}
