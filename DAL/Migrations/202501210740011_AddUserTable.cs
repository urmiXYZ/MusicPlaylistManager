namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Playlists", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Playlists", "UserId");
            AddForeignKey("dbo.Playlists", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Playlists", "UserId", "dbo.Users");
            DropIndex("dbo.Playlists", new[] { "UserId" });
            DropColumn("dbo.Playlists", "UserId");
            DropTable("dbo.Users");
        }
    }
}
