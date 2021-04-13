namespace DrywallCalc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "HireId", c => c.Int(nullable: false));
            DropColumn("dbo.Employee", "Hire_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Hire_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Employee", "HireId");
        }
    }
}
