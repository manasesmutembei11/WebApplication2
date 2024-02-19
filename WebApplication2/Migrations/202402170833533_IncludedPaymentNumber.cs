namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludedPaymentNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PaymentNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "PaymentNumber");
        }
    }
}
