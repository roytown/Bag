namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changelogs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Extend", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Extend");
        }
    }
}
