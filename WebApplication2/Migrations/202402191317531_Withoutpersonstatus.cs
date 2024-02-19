namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Withoutpersonstatus : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Status", c => c.Int(nullable: false));
        }
    }
}
