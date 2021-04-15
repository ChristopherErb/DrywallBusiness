namespace DrywallCalc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        JobOwnerId = c.Guid(nullable: false),
                        Address = c.String(),
                        Title = c.String(),
                        Owner = c.String(),
                        CurrentJobId = c.Int(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.JobOwnerId);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        MatOwnerID = c.Guid(nullable: false),
                        Screws = c.Int(nullable: false),
                        TwelveBoard = c.Int(nullable: false),
                        TenBoard = c.Int(nullable: false),
                        EightBoard = c.Int(nullable: false),
                        LightBlueMud = c.Int(nullable: false),
                        AllBlackMud = c.Int(nullable: false),
                        JobTitle = c.String(),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatOwnerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Material");
            DropTable("dbo.Job");
        }
    }
}
