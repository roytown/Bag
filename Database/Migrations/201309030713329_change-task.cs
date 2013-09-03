namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "ModifyTimes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "ModifyTimes");
        }
    }
}
