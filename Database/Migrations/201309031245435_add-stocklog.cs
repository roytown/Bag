namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstocklog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddTime = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 255),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.StockLogs", new[] { "TaskId" });
            DropForeignKey("dbo.StockLogs", "TaskId", "dbo.Tasks");
            DropTable("dbo.StockLogs");
        }
    }
}
