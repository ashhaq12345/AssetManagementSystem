namespace POS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category_required_unique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "ShortName", c => c.String(nullable: false, maxLength: 3));
            CreateIndex("dbo.Categories", "ShortName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "ShortName" });
            AlterColumn("dbo.Categories", "ShortName", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
