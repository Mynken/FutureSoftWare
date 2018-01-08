namespace FSW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AskQuestions", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.AskQuestions", "TextMessage", c => c.String(nullable: false, maxLength: 700));
            AlterColumn("dbo.Feedbacks", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Feedbacks", "Review", c => c.String(nullable: false, maxLength: 700));
            AlterColumn("dbo.OrderSites", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.OrderSites", "Surname", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.OrderSites", "Notes", c => c.String(maxLength: 700));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderSites", "Notes", c => c.String());
            AlterColumn("dbo.OrderSites", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.OrderSites", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Feedbacks", "Review", c => c.String(nullable: false));
            AlterColumn("dbo.Feedbacks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AskQuestions", "TextMessage", c => c.String(nullable: false));
            AlterColumn("dbo.AskQuestions", "Name", c => c.String(nullable: false));
        }
    }
}
