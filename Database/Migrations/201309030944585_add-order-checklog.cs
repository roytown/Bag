namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorderchecklog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderCheckLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        AddTime = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Type = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderCheckLogs", new[] { "Order_Id" });
            DropForeignKey("dbo.OrderCheckLogs", "Order_Id", "dbo.Orders");
            DropTable("dbo.OrderCheckLogs");
        }
    }
}
