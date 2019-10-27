namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDANOTATIONSTOCustomer1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime(nullable: false));
        }
    }
}
