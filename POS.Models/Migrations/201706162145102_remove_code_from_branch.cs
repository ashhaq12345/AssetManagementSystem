namespace POS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_code_from_branch : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Branches", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Branches", "Code", c => c.String());
        }
    }
}
