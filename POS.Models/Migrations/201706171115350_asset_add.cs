namespace POS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asset_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        GeneralCateforyId = c.Long(nullable: false),
                        CateforyId = c.Long(nullable: false),
                        ModelId = c.Long(nullable: false),
                        Price = c.Double(nullable: false),
                        Qty = c.Long(nullable: false),
                        SerialCode = c.String(),
                        Category_Id = c.Long(),
                        GeneralCategory_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.GeneralCategories", t => t.GeneralCategory_Id)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId)
                .Index(t => t.Category_Id)
                .Index(t => t.GeneralCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Assets", "GeneralCategory_Id", "dbo.GeneralCategories");
            DropForeignKey("dbo.Assets", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Assets", new[] { "GeneralCategory_Id" });
            DropIndex("dbo.Assets", new[] { "Category_Id" });
            DropIndex("dbo.Assets", new[] { "ModelId" });
            DropTable("dbo.Assets");
        }
    }
}
