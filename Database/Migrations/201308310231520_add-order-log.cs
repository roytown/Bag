namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorderlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.String(nullable: false, maxLength: 100),
                        Num = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 255),
                        UserName = c.String(nullable: false, maxLength: 50),
                        AddTime = c.DateTime(nullable: false),
                        PublishUserName = c.String(maxLength: 50),
                        QualityUserName = c.String(maxLength: 50),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 255),
                        AddTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            AddColumn("dbo.Tasks", "DevelopUserName", c => c.String());
            DropColumn("dbo.Tasks", "ProduceUserName");
            DropColumn("dbo.Tasks", "QualityUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "QualityUserName", c => c.String());
            AddColumn("dbo.Tasks", "ProduceUserName", c => c.String());
            DropIndex("dbo.Logs", new[] { "TaskId" });
            DropIndex("dbo.Orders", new[] { "TaskId" });
            DropForeignKey("dbo.Logs", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Orders", "TaskId", "dbo.Tasks");
            DropColumn("dbo.Tasks", "DevelopUserName");
            DropTable("dbo.Logs");
            DropTable("dbo.Orders");
        }
    }
}
