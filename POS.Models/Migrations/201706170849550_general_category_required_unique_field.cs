namespace POS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class general_category_required_unique_field : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GeneralCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.GeneralCategories", "ShortName", c => c.String(nullable: false, maxLength: 2));
            CreateIndex("dbo.GeneralCategories", "ShortName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.GeneralCategories", new[] { "ShortName" });
            AlterColumn("dbo.GeneralCategories", "ShortName", c => c.String());
            AlterColumn("dbo.GeneralCategories", "Name", c => c.String());
        }
    }
}
