namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderExpands", "Description", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderExpands", "Description", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
