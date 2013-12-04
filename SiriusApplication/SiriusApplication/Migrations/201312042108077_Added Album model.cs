namespace SiriusApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlbummodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumID);
            
            AddColumn("dbo.Images", "Album_AlbumID", c => c.Int());
            AlterColumn("dbo.Images", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Images", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.Comments", "Subject", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Comments", "Body", c => c.String(maxLength: 250));
            AddForeignKey("dbo.Images", "Album_AlbumID", "dbo.Albums", "AlbumID");
            CreateIndex("dbo.Images", "Album_AlbumID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Images", new[] { "Album_AlbumID" });
            DropForeignKey("dbo.Images", "Album_AlbumID", "dbo.Albums");
            AlterColumn("dbo.Comments", "Body", c => c.String());
            AlterColumn("dbo.Comments", "Subject", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Images", "Description", c => c.String());
            AlterColumn("dbo.Images", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Images", "Album_AlbumID");
            DropTable("dbo.Albums");
        }
    }
}
