namespace FSW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderSite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderSites",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Phone = c.String(),
                        Email = c.String(nullable: false),
                        TariffPlan = c.String(),
                        Notes = c.String(),
                        isCheked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.AskQuestions", "isCheked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AskQuestions", "isCheked");
            DropTable("dbo.OrderSites");
        }
    }
}
