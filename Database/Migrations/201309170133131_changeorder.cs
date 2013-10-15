namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderExpands", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderExpands", new[] { "OrderId" });
            AlterColumn("dbo.Orders", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "Num", c => c.Int(nullable: false));
            DropTable("dbo.OrderExpands");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderExpands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Num = c.String(nullable: false, maxLength: 200),
                        Time = c.String(nullable: false, maxLength: 200),
                        AddTime = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 255),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Orders", "Num", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "Time", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.OrderExpands", "OrderId");
            AddForeignKey("dbo.OrderExpands", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
