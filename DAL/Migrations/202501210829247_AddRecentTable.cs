namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddRecentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecentlyPlayeds",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PlayedAt = c.DateTime(nullable: false),
                    UserId = c.Int(nullable: false),
                    SongId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: false) // Disable cascade delete for Song
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false) // Disable cascade delete for User
                .Index(t => t.UserId)
                .Index(t => t.SongId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.RecentlyPlayeds", "UserId", "dbo.Users");
            DropForeignKey("dbo.RecentlyPlayeds", "SongId", "dbo.Songs");
            DropIndex("dbo.RecentlyPlayeds", new[] { "SongId" });
            DropIndex("dbo.RecentlyPlayeds", new[] { "UserId" });
            DropTable("dbo.RecentlyPlayeds");
        }
    }
}
