namespace SteamApiTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumOfStars = c.Int(nullable: false),
                        ListOwner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ListOwner_Id, cascadeDelete: true)
                .Index(t => t.ListOwner_Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GBID = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Country = c.String(),
                        DoB = c.DateTime(nullable: false),
                        Steam64 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameGameLists",
                c => new
                    {
                        Game_Id = c.Int(nullable: false),
                        GameList_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.GameList_Id })
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .ForeignKey("dbo.GameLists", t => t.GameList_Id, cascadeDelete: true)
                .Index(t => t.Game_Id)
                .Index(t => t.GameList_Id);
            
            CreateTable(
                "dbo.GameUsers",
                c => new
                    {
                        Game_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.User_Id })
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Game_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GameUsers", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.GameLists", "ListOwner_Id", "dbo.Users");
            DropForeignKey("dbo.GameGameLists", "GameList_Id", "dbo.GameLists");
            DropForeignKey("dbo.GameGameLists", "Game_Id", "dbo.Games");
            DropIndex("dbo.GameUsers", new[] { "User_Id" });
            DropIndex("dbo.GameUsers", new[] { "Game_Id" });
            DropIndex("dbo.GameGameLists", new[] { "GameList_Id" });
            DropIndex("dbo.GameGameLists", new[] { "Game_Id" });
            DropIndex("dbo.GameLists", new[] { "ListOwner_Id" });
            DropTable("dbo.GameUsers");
            DropTable("dbo.GameGameLists");
            DropTable("dbo.Users");
            DropTable("dbo.Games");
            DropTable("dbo.GameLists");
        }
    }
}
