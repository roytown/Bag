namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtaskattr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Model", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Type", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Materail", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Quality", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Brand", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Color", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Hardness", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Fineness", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Size", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Pattern", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Bigness", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Price", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Style", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Texture", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "InternalStructure", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "CarryPart", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Collapse", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tasks", "Situation", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "PopularElement", c => c.String(maxLength: 100));
            AddColumn("dbo.Tasks", "Ecp", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Ecp");
            DropColumn("dbo.Tasks", "PopularElement");
            DropColumn("dbo.Tasks", "Situation");
            DropColumn("dbo.Tasks", "Collapse");
            DropColumn("dbo.Tasks", "CarryPart");
            DropColumn("dbo.Tasks", "InternalStructure");
            DropColumn("dbo.Tasks", "Texture");
            DropColumn("dbo.Tasks", "Style");
            DropColumn("dbo.Tasks", "Price");
            DropColumn("dbo.Tasks", "Bigness");
            DropColumn("dbo.Tasks", "Pattern");
            DropColumn("dbo.Tasks", "Size");
            DropColumn("dbo.Tasks", "Fineness");
            DropColumn("dbo.Tasks", "Hardness");
            DropColumn("dbo.Tasks", "Color");
            DropColumn("dbo.Tasks", "Brand");
            DropColumn("dbo.Tasks", "Quality");
            DropColumn("dbo.Tasks", "Materail");
            DropColumn("dbo.Tasks", "Type");
            DropColumn("dbo.Tasks", "Model");
        }
    }
}
