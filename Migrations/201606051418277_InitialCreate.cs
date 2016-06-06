namespace SteamApiTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        GBEyeD = c.Int(nullable: false),
                        NumOfChecks = c.Int(nullable: false),
                        Name = c.String(),
                        CheckedByUser_Id = c.Int(),
                        GameList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CheckedByUser_Id)
                .ForeignKey("dbo.GameLists", t => t.GameList_Id)
                .Index(t => t.CheckedByUser_Id)
                .Index(t => t.GameList_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        Steam64 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameLists", "ListOwner_Id", "dbo.Users");
            DropForeignKey("dbo.Games", "GameList_Id", "dbo.GameLists");
            DropForeignKey("dbo.Games", "CheckedByUser_Id", "dbo.Users");
            DropIndex("dbo.Games", new[] { "GameList_Id" });
            DropIndex("dbo.Games", new[] { "CheckedByUser_Id" });
            DropIndex("dbo.GameLists", new[] { "ListOwner_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Games");
            DropTable("dbo.GameLists");
        }
    }
}
