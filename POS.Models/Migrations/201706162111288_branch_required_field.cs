namespace POS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class branch_required_field : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Branches", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Branches", "ShortName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Branches", "ShortName", c => c.String());
            AlterColumn("dbo.Branches", "Name", c => c.String());
        }
    }
}
