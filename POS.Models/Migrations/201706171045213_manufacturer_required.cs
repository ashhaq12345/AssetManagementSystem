namespace POS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manufacturer_required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Manufacturers", "Name", c => c.String());
        }
    }
}
