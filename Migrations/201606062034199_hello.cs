namespace SteamApiTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "CheckedByUser_Id", "dbo.Users");
            DropIndex("dbo.Games", new[] { "CheckedByUser_Id" });
            CreateTable(
                "dbo.UserGames",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Game_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Game_Id);
            
            DropColumn("dbo.Games", "CheckedByUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "CheckedByUser_Id", c => c.Int());
            DropForeignKey("dbo.UserGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.UserGames", "User_Id", "dbo.Users");
            DropIndex("dbo.UserGames", new[] { "Game_Id" });
            DropIndex("dbo.UserGames", new[] { "User_Id" });
            DropTable("dbo.UserGames");
            CreateIndex("dbo.Games", "CheckedByUser_Id");
            AddForeignKey("dbo.Games", "CheckedByUser_Id", "dbo.Users", "Id");
        }
    }
}
