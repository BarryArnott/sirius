namespace SiriusApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
        }

        //public override void Up()
        //{
        //    CreateTable(
        //        "dbo.Images",
        //        c => new
        //            {
        //                ImageID = c.Int(nullable: false, identity: true),
        //                Title = c.String(nullable: false),
        //                ImageFile = c.Binary(),
        //                ImageMimeType = c.String(),
        //                Description = c.String(),
        //                CreatedDate = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.ImageID);
            
        //    CreateTable(
        //        "dbo.Comments",
        //        c => new
        //            {
        //                CommentID = c.Int(nullable: false, identity: true),
        //                ImageID = c.Int(nullable: false),
        //                Subject = c.String(nullable: false, maxLength: 250),
        //                Body = c.String(),
        //            })
        //        .PrimaryKey(t => t.CommentID)
        //        .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: true)
        //        .Index(t => t.ImageID);
            
        //}
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "ImageID" });
            DropForeignKey("dbo.Comments", "ImageID", "dbo.Images");
            DropTable("dbo.Comments");
            DropTable("dbo.Images");
        }
    }
}
