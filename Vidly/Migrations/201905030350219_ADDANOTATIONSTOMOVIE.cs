namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDANOTATIONSTOMOVIE : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "DateAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
