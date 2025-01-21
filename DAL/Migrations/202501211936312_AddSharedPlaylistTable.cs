namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSharedPlaylistTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SharedPlaylists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaylistId = c.Int(nullable: false),
                        SharedWithUserId = c.Int(nullable: false),
                        SharedByUserId = c.Int(nullable: false),
                        AccessLevel = c.String(),
                        SharedDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlists", t => t.PlaylistId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.SharedByUserId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.SharedWithUserId, cascadeDelete: false)
                .Index(t => t.PlaylistId)
                .Index(t => t.SharedWithUserId)
                .Index(t => t.SharedByUserId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SharedPlaylists", "SharedWithUserId", "dbo.Users");
            DropForeignKey("dbo.SharedPlaylists", "SharedByUserId", "dbo.Users");
            DropForeignKey("dbo.SharedPlaylists", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SharedPlaylists", "PlaylistId", "dbo.Playlists");
            DropIndex("dbo.SharedPlaylists", new[] { "User_Id" });
            DropIndex("dbo.SharedPlaylists", new[] { "SharedByUserId" });
            DropIndex("dbo.SharedPlaylists", new[] { "SharedWithUserId" });
            DropIndex("dbo.SharedPlaylists", new[] { "PlaylistId" });
            DropTable("dbo.SharedPlaylists");
        }
    }
}
