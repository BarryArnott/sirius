namespace SiriusApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "AlbumID", "dbo.Albums");
            DropForeignKey("dbo.Comments", "ImageID", "dbo.Images");
            DropIndex("dbo.Images", new[] { "AlbumID" });
            DropIndex("dbo.Comments", new[] { "ImageID" });
            AddColumn("dbo.Images", "UploadedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Images", "ImageTakenOnDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Images", "IsoRating", c => c.String(maxLength: 7));
            AddColumn("dbo.Images", "FocalLength", c => c.String(maxLength: 10));
            AddColumn("dbo.Images", "Aperture", c => c.String(maxLength: 5));
            AddColumn("dbo.Images", "ShutterSpeed", c => c.String(maxLength: 12));
            AlterColumn("dbo.Images", "ImageId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Images", "AlbumId", c => c.Int());
            AlterColumn("dbo.Albums", "AlbumId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Images", new[] { "ImageID" });
            AddPrimaryKey("dbo.Images", "ImageId");
            DropPrimaryKey("dbo.Albums", new[] { "AlbumID" });
            AddPrimaryKey("dbo.Albums", "AlbumId");
            AddForeignKey("dbo.Images", "AlbumId", "dbo.Albums", "AlbumId");
            AddForeignKey("dbo.Comments", "ImageID", "dbo.Images", "ImageId", cascadeDelete: true);
            CreateIndex("dbo.Images", "AlbumId");
            CreateIndex("dbo.Comments", "ImageID");
            DropColumn("dbo.Images", "CreatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "CreatedDate", c => c.DateTime(nullable: false));
            DropIndex("dbo.Comments", new[] { "ImageID" });
            DropIndex("dbo.Images", new[] { "AlbumId" });
            DropForeignKey("dbo.Comments", "ImageID", "dbo.Images");
            DropForeignKey("dbo.Images", "AlbumId", "dbo.Albums");
            DropPrimaryKey("dbo.Albums", new[] { "AlbumId" });
            AddPrimaryKey("dbo.Albums", "AlbumID");
            DropPrimaryKey("dbo.Images", new[] { "ImageId" });
            AddPrimaryKey("dbo.Images", "ImageID");
            AlterColumn("dbo.Albums", "AlbumID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Images", "AlbumID", c => c.Int());
            AlterColumn("dbo.Images", "ImageID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Images", "ShutterSpeed");
            DropColumn("dbo.Images", "Aperture");
            DropColumn("dbo.Images", "FocalLength");
            DropColumn("dbo.Images", "IsoRating");
            DropColumn("dbo.Images", "ImageTakenOnDate");
            DropColumn("dbo.Images", "UploadedDate");
            CreateIndex("dbo.Comments", "ImageID");
            CreateIndex("dbo.Images", "AlbumID");
            AddForeignKey("dbo.Comments", "ImageID", "dbo.Images", "ImageID", cascadeDelete: true);
            AddForeignKey("dbo.Images", "AlbumID", "dbo.Albums", "AlbumID");
        }
    }
}
