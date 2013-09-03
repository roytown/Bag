namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelogstartusername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "StartUserName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Logs", "EndUserName", c => c.String(maxLength: 50));
            DropColumn("dbo.Logs", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "UserName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Logs", "EndUserName");
            DropColumn("dbo.Logs", "StartUserName");
        }
    }
}
