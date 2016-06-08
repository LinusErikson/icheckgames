namespace SteamApiTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picsforusers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PictureURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PictureURL");
        }
    }
}
