namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDANOTATIONSTOMOVIE1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
