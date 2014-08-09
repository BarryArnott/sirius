using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace SiriusApplication.Models
{
    public class SiriusApplicationInitializer : DropCreateDatabaseAlways<SiriusApplicationContext>
    {
        protected override void Seed(SiriusApplicationContext context)
        {
            base.Seed(context);

            var albums = new List<Album>
            {
                new Album 
                {
                    AlbumId = 1,
                    Title = "No Album Found",
                    Description = "Woops! There appears to have been no album found",
                    AlbumCoverFile = this.GetFileBytes("\\Content\\Images\\SharedImages\\no_image.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Now.AddDays(-1)
                },
                new Album 
                {
                    AlbumId = 2,
                    Title = "London Night Shoot",
                    Description = "London by night",
                    AlbumCoverFile = this.GetFileBytes("\\Content\\Images\\Photography\\02_untitled_29032014_thumbnail.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Now
                },
                new Album 
                {
                    AlbumId = 3,
                    Title = "Red Bull FlugTag",
                    Description = "Red Bull FlugTag held at Alexandra Palace",
                    AlbumCoverFile = this.GetFileBytes("\\Content\\Images\\Photography\\190_RedBull_14072013_thumbnail.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Now
                }
            };

            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();

            var images = new List<Image>
                             {
                                 new Image
                                     {
                                         Title = "No Image Found",
                                         Description = "No Image Found",
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\SharedImages\\no_image.jpg"),
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\SharedImages\\no_image.jpg"),
                                         ImageMimeType = "image/gif",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f4",
                                         FocalLength = "200mm",
                                         IsoRating = "100",
                                         ShutterSpeed = "1/250"
                                     },
                                 new Image 
                                 {
                                     AlbumId = 3,
                                     Title = "Bathtime",
                                     Description = "Getting prepared for the big race",
                                     ImageFileThumbnail = this.GetFileBytes("\\Content\\Images\\Photography\\09_RedBull_14072013_thumbnail.jpg"),
                                     ImageFileLarge = this.GetFileBytes("\\Content\\Images\\Photography\\09_RedBull_14072013_large.jpg"),
                                     ImageMimeType = "image/jpeg",
                                     UploadedDate = DateTime.Now,
                                     ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                     Aperture = "f5.6",
                                     FocalLength = "18mm",
                                     IsoRating = "100",
                                     ShutterSpeed = "1/1000",
                                     Latitude = 51.595371,
                                     Longitude = -0.127555
                                 },
                                 new Image 
                                 {
                                     AlbumId = 2,
                                     Title = "The chef",
                                     Description = "Looking a bit glum after wiping out on the first jump",
                                     ImageFileThumbnail = this.GetFileBytes("\\Content\\Images\\Photography\\110_RedBull_14072013_thumbnail.jpg"),
                                     ImageFileLarge = this.GetFileBytes("\\Content\\Images\\Photography\\110_RedBull_14072013_large.jpg"),
                                     ImageMimeType = "image/jpeg",
                                     UploadedDate = DateTime.Now,
                                     ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                     Aperture = "f5.0",
                                     FocalLength = "131mm",
                                     IsoRating = "100",
                                     ShutterSpeed = "1/800",
                                     Latitude = 51.595371,
                                     Longitude = -0.127555
                                 },
                                 new Image 
                                 {
                                     AlbumId = 2,
                                     Title = "Now then, now then",
                                     Description = "This guy was hilarious. Slapping a fine onto all the soap boxes which wiped out.",
                                     ImageFileThumbnail = this.GetFileBytes("\\Content\\Images\\Photography\\118_RedBull_14072013_thumbnail.jpg"),
                                     ImageFileLarge = this.GetFileBytes("\\Content\\Images\\Photography\\118_RedBull_14072013_large.jpg"),
                                     ImageMimeType = "image/jpeg",
                                     UploadedDate = DateTime.Now,
                                     ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                     Aperture = "f4.5",
                                     FocalLength = "55mm",
                                     IsoRating = "100",
                                     ShutterSpeed = "1/640",
                                     Latitude = 51.595371,
                                     Longitude = -0.127555
                                 },
                                 new Image 
                                 {
                                     AlbumId = 3,
                                     Title = "Castlemania",
                                     Description = "The only soap box on the day to use foot steering.",
                                     ImageFileThumbnail = this.GetFileBytes("\\Content\\Images\\Photography\\127_RedBull_14072013_thumbnail.jpg"),
                                     ImageFileLarge = this.GetFileBytes("\\Content\\Images\\Photography\\127_RedBull_14072013_large.jpg"),
                                     ImageMimeType = "image/jpeg",
                                     UploadedDate = DateTime.Now,
                                     ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                     Aperture = "f5.0",
                                     FocalLength = "90mm",
                                     IsoRating = "100",
                                     ShutterSpeed = "1/400",
                                     Latitude = 51.595371,
                                     Longitude = -0.127555
                                 },
                                 new Image 
                                 {
                                     AlbumId = 3,
                                     Title = "Peckhams finest",
                                     Description = "Completely fell apart after the first jump.",
                                     ImageFileThumbnail = this.GetFileBytes("\\Content\\Images\\Photography\\168_RedBull_14072013_thumbnail.jpg"),
                                     ImageFileLarge = this.GetFileBytes("\\Content\\Images\\Photography\\168_RedBull_14072013_large.jpg"),
                                     ImageMimeType = "image/jpeg",
                                     UploadedDate = DateTime.Now,
                                     ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                     Aperture = "f5.0",
                                     FocalLength = "74mm",
                                     IsoRating = "100",
                                     ShutterSpeed = "1/500",
                                     Latitude = 51.595371,
                                     Longitude = -0.127555
                                 },
                                 new Image 
                                 {
                                     AlbumId = 3,
                                     Title = "A man's best friend",
                                     Description = "These guys actually beat thier soap box to the bottom of the hill",
                                     ImageFileThumbnail = this.GetFileBytes("\\Content\\Images\\Photography\\189_RedBull_14072013_thumbnail.jpg"),
                                     ImageFileLarge = this.GetFileBytes("\\Content\\Images\\Photography\\189_RedBull_14072013_large.jpg"),
                                     ImageMimeType = "image/jpeg",
                                     UploadedDate = DateTime.Now,
                                     ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                     Aperture = "f5.0",
                                     FocalLength = "100mm",
                                     IsoRating = "100",
                                     ShutterSpeed = "1/640",
                                     Latitude = 51.595371,
                                     Longitude = -0.127555
                                 },
                                 new Image 
                                 {
                                     AlbumId = 3,
                                     Title = "Finish line?",
                                     Description = "The soap box in the background didn't make it.",
                                     ImageFileThumbnail = this.GetFileBytes("\\Content\\Images\\Photography\\190_RedBull_14072013_thumbnail.jpg"),
                                     ImageFileLarge = this.GetFileBytes("\\Content\\Images\\Photography\\190_RedBull_14072013_large.jpg"),
                                     ImageMimeType = "image/jpeg",
                                     UploadedDate = DateTime.Now,
                                     ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                     Aperture = "f4.5",
                                     FocalLength = "79mm",
                                     IsoRating = "100",
                                     ShutterSpeed = "1/640",
                                     Latitude = 51.595371,
                                     Longitude = -0.127555
                                 },
                                 new Image 
                                 {
                                     AlbumId = 3,
                                     Title = "Dinner time!",
                                     Description = "Was hard to get a good shot of these guys as I was laughing so much.",
                                     ImageFileThumbnail = this.GetFileBytes("\\Content\\Images\\Photography\\211_RedBull_14072013_thumbnail.jpg"),
                                     ImageFileLarge = this.GetFileBytes("\\Content\\Images\\Photography\\211_RedBull_14072013_large.jpg"),
                                     ImageMimeType = "image/jpeg",
                                     UploadedDate = DateTime.Now,
                                     ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                     Aperture = "f4.0",
                                     FocalLength = "55mm",
                                     IsoRating = "100",
                                     ShutterSpeed = "1/1000",
                                     Latitude = 51.595371,
                                     Longitude = -0.127555
                                 },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "Wellington Arch",
                                         Description = "My favourite monument in London.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\02_untitled_29032014_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\02_untitled_29032014_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f7.1",
                                         FocalLength = "25mm",
                                         IsoRating = "100",
                                         ShutterSpeed = "15 sec",
                                         Latitude = 51.502553,
                                         Longitude = -0.150894
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "Trafalgar Square Fountain",
                                         Description = "This place is awe inspiring at night.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\11_LondonNightShoot_12042014_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\11_LondonNightShoot_12042014_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f11",
                                         FocalLength = "18mm",
                                         IsoRating = "100",
                                         ShutterSpeed = "20 sec",
                                         Latitude = 51.507956,
                                         Longitude = -0.128713,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "National Gallery",
                                         Description = "This place is awe inspiring at night.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\13_LondonNightShoot_12042014_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\13_LondonNightShoot_12042014_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f11",
                                         FocalLength = "55mm",
                                         IsoRating = "100",
                                         ShutterSpeed = "2 sec",
                                         Latitude = 51.507956,
                                         Longitude = -0.128713,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "Wellington Arch",
                                         Description =
                                             "Wellington Arch viewed from the Bomber Command memorial.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\14_untitled_29032014_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\14_untitled_29032014_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f11",
                                         FocalLength = "42mm",
                                         IsoRating = "100",
                                         ShutterSpeed = "10 sec",
                                         Latitude = 51.502571,
                                         Longitude = -0.151785,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "Angel of Peace",
                                         Description = "This beauty sits on top of Wellington Arch.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\16_untitled_29032014_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\16_untitled_29032014_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f6.3",
                                         FocalLength = "250mm",
                                         IsoRating = "100",
                                         ShutterSpeed = "10 sec",
                                         Latitude = 51.502510,
                                         Longitude = -0.150774,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "London Skyline",
                                         Description = "Taken from the Golden Jubilee Bridge.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\32_untitled_29032014_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\32_untitled_29032014_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f9.0",
                                         FocalLength = "41mm",
                                         IsoRating = "100",
                                         ShutterSpeed = "13 sec",
                                         Latitude = 51.505908,
                                         Longitude = -0.120137,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "London Eye",
                                         Description = "Taken from the Golden Jubilee Bridge.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\35_untitled_29032014_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\35_untitled_29032014_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f7.1",
                                         FocalLength = "18mm",
                                         IsoRating = "100",
                                         ShutterSpeed = "25.0 sec",
                                         Latitude = 51.505908,
                                         Longitude = -0.120137,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "Victoria Tower",
                                         Description = "Often overshadowed by Elizabeth Tower.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\36_LondonNightShoot_12042014_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\36_LondonNightShoot_12042014_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f4.5",
                                         FocalLength = "84mm",
                                         IsoRating = "100",
                                         ShutterSpeed = "5.0 sec",
                                         Latitude = 51.498334,
                                         Longitude = -0.125596,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "St Pauls from the Millenium Bridge",
                                         Description =
                                             "The most beautiful building in London (probably).",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\45_untitled_29032014_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\45_untitled_29032014_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f8.0",
                                         FocalLength = "46mm",
                                         IsoRating = "100",
                                         ShutterSpeed = "25.0 sec",
                                         Latitude = 51.508070,
                                         Longitude = -0.098660,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "Tower Bridge",
                                         Description = "South side tower.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-47_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-47_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f4.5",
                                         FocalLength = "30mm",
                                         IsoRating = "800",
                                         ShutterSpeed = "1/20 sec",
                                         Latitude = 51.504248,
                                         Longitude = -0.076200,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "Tower Bridge",
                                         Description = "Never get tired of walking past this at night.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-54_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-54_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f13",
                                         FocalLength = "28mm",
                                         IsoRating = "200",
                                         ShutterSpeed = "6.0 sec",
                                         Latitude = 51.505624,
                                         Longitude = -0.075278,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "Elizabeth Tower",
                                         Description = "Bong!",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-77_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-77_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f4.0",
                                         FocalLength = "65mm",
                                         IsoRating = "200",
                                         ShutterSpeed = "0.5 sec",
                                         Latitude = 51.500735,
                                         Longitude = -0.124528,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "No introduction needed",
                                         Description = "Using the trusty tripod.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-82_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-82_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f11",
                                         FocalLength = "250mm",
                                         IsoRating = "400",
                                         ShutterSpeed = "0.8 sec",
                                         Latitude = 51.500735,
                                         Longitude = -0.124528,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "\"Revolving Torsion\" Fountain",
                                         Description = "Didn't even realise this was here until I stumbled upon it.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-87_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-87_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f11",
                                         FocalLength = "48mm",
                                         IsoRating = "400",
                                         ShutterSpeed = "4.0 sec",
                                         Latitude = 51.500369,
                                         Longitude = -0.119485,
                                     },
                                 new Image
                                     {
                                         AlbumId = 2,
                                         Title = "London Eye",
                                         Description = "Taken from the north bank.",
                                         ImageFileThumbnail =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-96_thumbnail.jpg"),
                                         ImageFileLarge =
                                             this.GetFileBytes(
                                                 "\\Content\\Images\\Photography\\01_LondonNightShoot_07122012-96_large.jpg"),
                                         ImageMimeType = "image/jpeg",
                                         UploadedDate = DateTime.Now,
                                         ImageTakenOnDate = DateTime.Today.AddDays(-100),
                                         Aperture = "f18",
                                         FocalLength = "25mm",
                                         IsoRating = "200",
                                         ShutterSpeed = "20.0 sec",
                                         Latitude = 51.503224,
                                         Longitude = -0.119607,
                                     }, 
                             };

            images.ForEach(s => context.Images.Add(s));
            context.SaveChanges();

            //var comments = new List<Comment>
            //{
            //    new Comment {
            //        ImageID = 1,
            //        Subject = "Glacier point",
            //        Body = "On a cold morning on top of Glacier point at Yosemite."
            //    },
            //    new Comment {
            //        ImageID = 1,
            //        Subject = "Brrrrr",
            //        Body = "Yeah, it was cold!"
            //    },
            //    new Comment {
            //        ImageID = 2,
            //        Subject = "Awesome",
            //        Body = "Completely inspiring."
            //    },
            //    new Comment {
            //        ImageID = 3,
            //        Subject = "Exploration",
            //        Body = "Mankinds curiosity holds no bounds."
            //    },
            //    new Comment {
            //        ImageID = 4,
            //        Subject = "In a galaxy, far far away....",
            //        Body = "Amazing to think we are seeing something as it was billions of years ago!"
            //    }
            //};

            //comments.ForEach(s => context.Comments.Add(s));
            //context.SaveChanges();
        }

        //This gets a byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] GetFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }

            return fileBytes;
        }
    }
}