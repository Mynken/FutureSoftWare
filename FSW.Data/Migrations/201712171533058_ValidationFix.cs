namespace FSW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Galleries", "Desciption", c => c.String(nullable: false, maxLength: 700));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Galleries", "Desciption", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
