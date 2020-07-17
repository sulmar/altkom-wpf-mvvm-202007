namespace Altkom.WPFMVVM.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPeselToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Pesel", c => c.String());
            Sql("UPDATE dbo.Customers SET Pesel = '99999999'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Pesel");
        }
    }
}
