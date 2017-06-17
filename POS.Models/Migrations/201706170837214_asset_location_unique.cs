namespace POS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asset_location_unique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssetLocations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AssetLocations", "ShortName", c => c.String(nullable: false, maxLength: 4));
            CreateIndex("dbo.AssetLocations", "ShortName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AssetLocations", new[] { "ShortName" });
            AlterColumn("dbo.AssetLocations", "ShortName", c => c.String());
            AlterColumn("dbo.AssetLocations", "Name", c => c.String());
        }
    }
}
