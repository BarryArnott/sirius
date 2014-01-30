namespace SiriusApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmendedAlbumIDonImagetoallownull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "AlbumID", "dbo.Albums");
            DropIndex("dbo.Images", new[] { "AlbumID" });
            AlterColumn("dbo.Images", "AlbumID", c => c.Int());
            AddForeignKey("dbo.Images", "AlbumID", "dbo.Albums", "AlbumID");
            CreateIndex("dbo.Images", "AlbumID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Images", new[] { "AlbumID" });
            DropForeignKey("dbo.Images", "AlbumID", "dbo.Albums");
            AlterColumn("dbo.Images", "AlbumID", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "AlbumID");
            AddForeignKey("dbo.Images", "AlbumID", "dbo.Albums", "AlbumID", cascadeDelete: true);
        }
    }
}
