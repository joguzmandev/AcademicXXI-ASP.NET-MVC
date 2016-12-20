namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredMetaToLineRecordStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LineRecordStudent", "LiteralScore", c => c.String(maxLength: 2));
            AlterColumn("dbo.LineRecordStudent", "NumericScore", c => c.Int(nullable: true));
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LineRecordStudent", "LiteralScore", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.LineRecordStudent", "NumericScore", c => c.Int(nullable: false));
        }
    }
}
