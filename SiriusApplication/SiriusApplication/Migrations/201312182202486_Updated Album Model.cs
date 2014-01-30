namespace SiriusApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAlbumModel : DbMigration
    {
        //public override void Up()
        //{
        //    AddColumn("dbo.Albums", "AlbumCoverFile", c => c.Binary());
        //    AddColumn("dbo.Albums", "AlbumCoverMimeType", c => c.String());
        //}

        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "AlbumCoverMimeType");
            DropColumn("dbo.Albums", "AlbumCoverFile");
        }
    }
}
