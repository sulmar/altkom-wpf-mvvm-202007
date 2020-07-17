namespace Altkom.WPFMVVM.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductsViews : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE VIEW dbo.vwProducts AS SELECT * FROM dbo.Products");
        }
        
        public override void Down()
        {
            Sql("DROP VIEW dbo.vwProducts");
        }
    }
}
