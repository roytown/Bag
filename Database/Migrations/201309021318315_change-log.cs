namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changelog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "RangeBegin", c => c.DateTime());
            AddColumn("dbo.Logs", "RangeEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "RangeEnd");
            DropColumn("dbo.Logs", "RangeBegin");
        }
    }
}
