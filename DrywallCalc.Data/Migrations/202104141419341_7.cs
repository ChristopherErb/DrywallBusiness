namespace DrywallCalc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employee");
            AlterColumn("dbo.Employee", "Employee_Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Employee", "Employee_Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employee");
            AlterColumn("dbo.Employee", "Employee_Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Employee", "Employee_Id");
        }
    }
}
