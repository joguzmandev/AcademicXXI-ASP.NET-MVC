namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddNuableField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LineRecordStudent", "NumericScore", c => c.Int(nullable: true));
        }

        public override void Down()
        {
            AlterColumn("dbo.LineRecordStudent", "NumericScore", c => c.Int(nullable: false));
        }
    }
}