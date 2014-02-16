namespace SiriusApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        AlbumID = c.Int(),
                        Title = c.String(nullable: false, maxLength: 50),
                        ImageFile = c.Binary(),
                        ImageMimeType = c.String(),
                        Description = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.Albums", t => t.AlbumID)
                .Index(t => t.AlbumID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        ImageID = c.Int(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 50),
                        Body = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: true)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        AlbumCoverFile = c.Binary(),
                        AlbumCoverMimeType = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "ImageID" });
            DropIndex("dbo.Images", new[] { "AlbumID" });
            DropForeignKey("dbo.Comments", "ImageID", "dbo.Images");
            DropForeignKey("dbo.Images", "AlbumID", "dbo.Albums");
            DropTable("dbo.Albums");
            DropTable("dbo.Comments");
            DropTable("dbo.Images");
        }
    }
}
