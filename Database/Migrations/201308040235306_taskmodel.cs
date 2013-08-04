namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taskmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Title", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Tasks", "Code", c => c.String(maxLength: 50));
            AddColumn("dbo.Tasks", "Customer", c => c.String(maxLength: 20));
            AddColumn("dbo.Tasks", "TelePhone", c => c.String(maxLength: 20));
            AddColumn("dbo.Tasks", "MobilePhone", c => c.String(maxLength: 20));
            AddColumn("dbo.Tasks", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "AddTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tasks", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Tasks", "AddTime");
            DropColumn("dbo.Tasks", "Status");
            DropColumn("dbo.Tasks", "MobilePhone");
            DropColumn("dbo.Tasks", "TelePhone");
            DropColumn("dbo.Tasks", "Customer");
            DropColumn("dbo.Tasks", "Code");
            DropColumn("dbo.Tasks", "Title");
        }
    }
}
