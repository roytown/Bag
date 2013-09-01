namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsConfirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsConfirmed");
        }
    }
}
