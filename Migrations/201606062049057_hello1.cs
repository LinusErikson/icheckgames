namespace SteamApiTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGames", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserGames", "Game_Id", "dbo.Games");
            DropIndex("dbo.UserGames", new[] { "User_Id" });
            DropIndex("dbo.UserGames", new[] { "Game_Id" });
            AddColumn("dbo.Users", "GamesChecked_Id", c => c.Int());
            CreateIndex("dbo.Users", "GamesChecked_Id");
            AddForeignKey("dbo.Users", "GamesChecked_Id", "dbo.Games", "Id");
            DropTable("dbo.UserGames");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserGames",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Game_Id });
            
            DropForeignKey("dbo.Users", "GamesChecked_Id", "dbo.Games");
            DropIndex("dbo.Users", new[] { "GamesChecked_Id" });
            DropColumn("dbo.Users", "GamesChecked_Id");
            CreateIndex("dbo.UserGames", "Game_Id");
            CreateIndex("dbo.UserGames", "User_Id");
            AddForeignKey("dbo.UserGames", "Game_Id", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserGames", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
