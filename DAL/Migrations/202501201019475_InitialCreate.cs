namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Artist = c.String(),
                        Album = c.String(),
                        Lyrics = c.String(),
                        PlaylistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlists", t => t.PlaylistId, cascadeDelete: true)
                .Index(t => t.PlaylistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "PlaylistId", "dbo.Playlists");
            DropIndex("dbo.Songs", new[] { "PlaylistId" });
            DropTable("dbo.Songs");
            DropTable("dbo.Playlists");
        }
    }
}
