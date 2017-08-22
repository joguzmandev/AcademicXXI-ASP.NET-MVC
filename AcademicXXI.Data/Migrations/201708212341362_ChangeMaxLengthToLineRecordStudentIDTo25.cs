namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMaxLengthToLineRecordStudentIDTo25 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LineRecordStudent");
            AlterColumn("dbo.LineRecordStudent", "LineRecordStudentID", c => c.String(nullable: false, maxLength: 25));
            AddPrimaryKey("dbo.LineRecordStudent", "LineRecordStudentID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LineRecordStudent");
            AlterColumn("dbo.LineRecordStudent", "LineRecordStudentID", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.LineRecordStudent", "LineRecordStudentID");
        }
    }
}
