namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderexpand : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderExpands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Num = c.String(nullable: false, maxLength: 200),
                        AddTime = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 255),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "IsConfirmed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "IsConfirmed", c => c.Boolean(nullable: false));
            DropIndex("dbo.OrderExpands", new[] { "OrderId" });
            DropForeignKey("dbo.OrderExpands", "OrderId", "dbo.Orders");
            DropColumn("dbo.Orders", "Status");
            DropTable("dbo.OrderExpands");
        }
    }
}
