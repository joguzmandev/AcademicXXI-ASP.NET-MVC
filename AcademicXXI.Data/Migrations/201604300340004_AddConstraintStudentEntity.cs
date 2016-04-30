namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraintStudentEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 30, storeType: "nvarchar"));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 30, storeType: "nvarchar"));
            AlterColumn("dbo.Students", "DocumentID", c => c.String(nullable: false, maxLength: 11, storeType: "nvarchar"));
            AlterColumn("dbo.Students", "RegisterNumber", c => c.String(nullable: false, maxLength: 10, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "RegisterNumber", c => c.String(unicode: false));
            AlterColumn("dbo.Students", "DocumentID", c => c.String(unicode: false));
            AlterColumn("dbo.Students", "LastName", c => c.String(unicode: false));
            AlterColumn("dbo.Students", "FirstName", c => c.String(unicode: false));
        }
    }
}
