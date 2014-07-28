namespace SiriusApplication.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddLargeAndThumbnail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageFileThumbnail", c => c.Binary());
            AddColumn("dbo.Images", "ImageFileLarge", c => c.Binary());
            DropColumn("dbo.Images", "ImageFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "ImageFile", c => c.Binary());
            DropColumn("dbo.Images", "ImageFileLarge");
            DropColumn("dbo.Images", "ImageFileThumbnail");
        }
    }
}
