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
                    Title = "Album 2",
                    Description = "Yosemite",
                    AlbumCoverFile = this.GetFileBytes("\\Content\\Images\\Photography\\01.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Now.AddDays(-1)
                },

                new Album 
                {
                    AlbumId = 3,
                    Title = "Album 3",
                    Description = "Space",
                    AlbumCoverFile = this.GetFileBytes("\\Content\\Images\\Photography\\02.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Now.AddDays(-2)
                },
                new Album 
                {
                    AlbumId = 4,
                    Title = "Album 4",
                    Description = "Twister",
                    AlbumCoverFile = this.GetFileBytes("\\Content\\Images\\Photography\\05.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Now.AddDays(-3)
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
                    ImageFile = this.GetFileBytes("\\Content\\Images\\SharedImages\\no_image.jpg"),
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
                    AlbumId = 2,
                    Title = "Yosemite",
                    Description = "Yosemite 2011",
                    ImageFile = this.GetFileBytes("\\Content\\Images\\Photography\\01.jpg"),
                    ImageMimeType = "image/jpeg",
                    UploadedDate = DateTime.Now.AddDays(-4),
                    ImageTakenOnDate = DateTime.Today.AddDays(-100),
                    Aperture = "f2",
                    FocalLength = "200mm",
                    IsoRating = "200",
                    ShutterSpeed = "1/200",
                    Latitude = 37.6738966,
                    Longitude = -119.63785009999998
                },

                new Image 
                {
                    AlbumId = 2,
                    Title = "Space Shuttle",
                    Description = "Launch of the space shuttle",
                    ImageFile = this.GetFileBytes("\\Content\\Images\\Photography\\02.jpg"),
                    ImageMimeType = "image/jpeg",
                    UploadedDate = DateTime.Now.AddDays(-3),
                    ImageTakenOnDate = DateTime.Today.AddDays(-100),
                    Aperture = "f3",
                    FocalLength = "300mm",
                    IsoRating = "300",
                    ShutterSpeed = "1/300",
                    Latitude = 27.664827400000000000,
                    Longitude = -81.515753500000020000
                },

                new Image 
                {
                    AlbumId = 2,
                    Title = "Opportunity",
                    Description = "Opportunity rover on Mars",
                    ImageFile = this.GetFileBytes("\\Content\\Images\\Photography\\03.jpg"),
                    ImageMimeType = "image/jpeg",
                    UploadedDate = DateTime.Now.AddDays(-2),
                    ImageTakenOnDate = DateTime.Today.AddDays(-100),
                    Aperture = "f4",
                    FocalLength = "400mm",
                    IsoRating = "400",
                    ShutterSpeed = "1/400",
                    Latitude = 29.5519914,
                    Longitude = -95.0882451
                },

                new Image 
                {
                    AlbumId = 2,
                    Title = "Hubble",
                    Description = "Hubble Deep Field",
                    ImageFile = this.GetFileBytes("\\Content\\Images\\Photography\\04.jpg"),
                    ImageMimeType = "image/jpeg",
                    UploadedDate = DateTime.Now.AddDays(-1),
                    ImageTakenOnDate = DateTime.Today.AddDays(-100),
                    Aperture = "f5",
                    FocalLength = "500mm",
                    IsoRating = "500",
                    ShutterSpeed = "1/500",
                    Latitude = 35.2678077,
                    Longitude = -116.77705040000001
                },

                new Image 
                {
                    AlbumId = 2,
                    Title = "Twister",
                    Description = "Twister in USA",
                    ImageFile = this.GetFileBytes("\\Content\\Images\\Photography\\05.jpg"),
                    ImageMimeType = "image/jpeg",
                    UploadedDate = DateTime.Now,
                    ImageTakenOnDate = DateTime.Today.AddDays(-100),
                    Aperture = "f6",
                    FocalLength = "600mm",
                    IsoRating = "600",
                    ShutterSpeed = "1/600",
                    Latitude = 54.906869000000000000,
                    Longitude = -1.383800999999948500
                }
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