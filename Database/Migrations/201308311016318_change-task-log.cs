namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetasklog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Action", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Action");
        }
    }
}
