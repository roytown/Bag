namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeorderexpand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderExpands", "Time", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderExpands", "Time");
        }
    }
}
