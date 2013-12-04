namespace SiriusApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlbumIDtoimagemodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Album_AlbumID", "dbo.Albums");
            DropIndex("dbo.Images", new[] { "Album_AlbumID" });
            RenameColumn(table: "dbo.Images", name: "Album_AlbumID", newName: "AlbumID");
            AddForeignKey("dbo.Images", "AlbumID", "dbo.Albums", "AlbumID", cascadeDelete: true);
            CreateIndex("dbo.Images", "AlbumID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Images", new[] { "AlbumID" });
            DropForeignKey("dbo.Images", "AlbumID", "dbo.Albums");
            RenameColumn(table: "dbo.Images", name: "AlbumID", newName: "Album_AlbumID");
            CreateIndex("dbo.Images", "Album_AlbumID");
            AddForeignKey("dbo.Images", "Album_AlbumID", "dbo.Albums", "AlbumID");
        }
    }
}
