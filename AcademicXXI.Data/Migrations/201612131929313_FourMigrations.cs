namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourMigrations : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RecordDetails", name: "Id", newName: "RecordDetailId");
            DropPrimaryKey("dbo.LineRecordStudent");
            AddColumn("dbo.LineRecordStudent", "LineRecordStudentID", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.LineRecordStudent", "LineRecordStudentID");
            DropColumn("dbo.LineRecordStudent", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LineRecordStudent", "Id", c => c.String(nullable: false, maxLength: 20));
            DropPrimaryKey("dbo.LineRecordStudent");
            DropColumn("dbo.LineRecordStudent", "LineRecordStudentID");
            AddPrimaryKey("dbo.LineRecordStudent", "Id");
            RenameColumn(table: "dbo.RecordDetails", name: "RecordDetailId", newName: "Id");
        }
    }
}
