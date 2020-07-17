namespace Altkom.WPFMVVM.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        Part_Id = c.Int(),
                        Action_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.Part_Id)
                .ForeignKey("dbo.Actions", t => t.Action_Id)
                .Index(t => t.Part_Id)
                .Index(t => t.Action_Id);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SerialNumber = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Photo = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsRemoved = c.Boolean(nullable: false),
                        Gender = c.Byte(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Color = c.String(maxLength: 50),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C = c.Int(nullable: false),
                        M = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        K = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Events", "Action_Id", "dbo.Actions");
            DropForeignKey("dbo.Events", "Part_Id", "dbo.Parts");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Events", new[] { "Action_Id" });
            DropIndex("dbo.Events", new[] { "Part_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
            DropTable("dbo.Parts");
            DropTable("dbo.Events");
            DropTable("dbo.Actions");
        }
    }
}
