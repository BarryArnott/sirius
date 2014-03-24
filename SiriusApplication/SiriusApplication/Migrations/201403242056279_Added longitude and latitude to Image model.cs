//namespace SiriusApplication.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class AddedlongitudeandlatitudetoImagemodel : DbMigration
//    {
//        public override void Up()
//        {
//            AddColumn("dbo.Images", "Latitude", c => c.Double(nullable: false));
//            AddColumn("dbo.Images", "Longitude", c => c.Double(nullable: false));
//        }
        
//        public override void Down()
//        {
//            DropColumn("dbo.Images", "Longitude");
//            DropColumn("dbo.Images", "Latitude");
//        }
//    }
//}
