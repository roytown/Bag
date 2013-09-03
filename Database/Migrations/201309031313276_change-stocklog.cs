namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestocklog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockLogs", "HasOrder", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockLogs", "HasOrder");
        }
    }
}
