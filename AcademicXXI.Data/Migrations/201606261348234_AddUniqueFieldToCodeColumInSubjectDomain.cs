namespace AcademicXXI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueFieldToCodeColumInSubjectDomain : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Subjects", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Subjects", new[] { "Code" });
        }
    }
}
