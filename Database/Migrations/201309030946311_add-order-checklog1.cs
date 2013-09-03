namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorderchecklog1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderCheckLogs", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderCheckLogs", new[] { "Order_Id" });
            RenameColumn(table: "dbo.OrderCheckLogs", name: "Order_Id", newName: "OrderId");
            AddForeignKey("dbo.OrderCheckLogs", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            CreateIndex("dbo.OrderCheckLogs", "OrderId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderCheckLogs", new[] { "OrderId" });
            DropForeignKey("dbo.OrderCheckLogs", "OrderId", "dbo.Orders");
            RenameColumn(table: "dbo.OrderCheckLogs", name: "OrderId", newName: "Order_Id");
            CreateIndex("dbo.OrderCheckLogs", "Order_Id");
            AddForeignKey("dbo.OrderCheckLogs", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
