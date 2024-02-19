namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Withpersonstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Status");
        }
    }
}
