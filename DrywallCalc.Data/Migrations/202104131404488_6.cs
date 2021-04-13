namespace DrywallCalc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employee", "HireId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "HireId", c => c.Int(nullable: false));
        }
    }
}
