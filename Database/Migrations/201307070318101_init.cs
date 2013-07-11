namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        JoinTime = c.DateTime(nullable: false),
                        RndPassword = c.String(maxLength: 20),
                        Email = c.String(maxLength: 20),
                        LastLoginTime = c.DateTime(),
                        LastLoginIP = c.String(maxLength: 20),
                        FirstFailedPasswordAttempTime = c.DateTime(),
                        FailedPasswordAttemptCount = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Description = c.String(maxLength: 255),
                        Purview = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User_Role",
                c => new
                    {
                        UID = c.Int(nullable: false),
                        RID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UID, t.RID })
                .ForeignKey("dbo.Users", t => t.UID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RID, cascadeDelete: true)
                .Index(t => t.UID)
                .Index(t => t.RID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.User_Role", new[] { "RID" });
            DropIndex("dbo.User_Role", new[] { "UID" });
            DropForeignKey("dbo.User_Role", "RID", "dbo.Roles");
            DropForeignKey("dbo.User_Role", "UID", "dbo.Users");
            DropTable("dbo.User_Role");
            DropTable("dbo.Tasks");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
        }
    }
}
