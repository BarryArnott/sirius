using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace SiriusApplication.Models
{
    public class SiriusApplicationInitializer : DropCreateDatabaseAlways<SiriusApplicationContext>
    {
        //This gets a byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }

            return fileBytes;
        }

        protected override void Seed(SiriusApplicationContext context)
        {
            base.Seed(context);

            var albums = new List<Album>
            {
                new Album {
                    AlbumId = 1,
                    Title = "Album 1",
                    Description = "this is some text in the second columnthis is some text in the first columnthis is some text in the first columnthis is some text in the first columnthis is some text in the first column",
                    AlbumCoverFile = getFileBytes("\\Content\\Images\\Photography\\01.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Now.AddDays(-1)
                },
                new Album {
                    AlbumId = 2,
                    Title = "Album 2",
                    Description = "this is some text in the second columnthis is some text in the first columnthis is some text in the first columnthis is some text in the first columnthis is some text in the first column",
                    AlbumCoverFile = getFileBytes("\\Content\\Images\\Photography\\02.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Now.AddDays(-2)
                },
                new Album {
                    AlbumId = 3,
                    Title = "Album 3",
                    Description = "this is some text in the second columnthis is some text in the first columnthis is some text in the first columnthis is some text in the first columnthis is some text in the first column",
                    AlbumCoverFile = getFileBytes("\\Content\\Images\\Photography\\03.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Now.AddDays(-3)
                },
                new Album {
                    AlbumId = 4,
                    Title = "Album 4",
                    Description = "this is some text in the second columnthis is some text in the first columnthis is some text in the first columnthis is some text in the first columnthis is some text in the first column",
                    AlbumCoverFile = getFileBytes("\\Content\\Images\\Photography\\04.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Now.AddDays(-4)
                }
            };

            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();

            var images = new List<Image>
            {
                new Image {
                    Title = "No Image Found",
                    Description = "No Image Found",
                    ImageFile = getFileBytes("\\Content\\Images\\SharedImages\\no_album_image.jpg"),
                    ImageMimeType = "image/gif",
                    UploadedDate = DateTime.Today,
                    ImageTakenOnDate = DateTime.Today
                },
                new Image {
                    AlbumId = 1,
                    Title = "Yosemite",
                    Description = "Yosemite 2011",
                    ImageFile = getFileBytes("\\Content\\Images\\Photography\\01.jpg"),
                    ImageMimeType = "image/jpeg",
                    UploadedDate = DateTime.Today,
                    ImageTakenOnDate = DateTime.Today
                },
                new Image {
                    AlbumId = 2,
                    Title = "Space Shuttle",
                    Description = "Launch of the space shuttle",
                    ImageFile = getFileBytes("\\Content\\Images\\Photography\\02.jpg"),
                    ImageMimeType = "image/jpeg",
                    UploadedDate = DateTime.Today,
                    ImageTakenOnDate = DateTime.Today
                },
                new Image {
                    AlbumId = 2,
                    Title = "Opportunity",
                    Description = "Opportunity rover on Mars",
                    ImageFile = getFileBytes("\\Content\\Images\\Photography\\03.jpg"),
                    ImageMimeType = "image/jpeg",
                    UploadedDate = DateTime.Today,
                    ImageTakenOnDate = DateTime.Today
                },
                new Image {
                    AlbumId = 2,
                    Title = "Hubble",
                    Description = "Hubble Deep Field",
                    ImageFile = getFileBytes("\\Content\\Images\\Photography\\04.jpg"),
                    ImageMimeType = "image/jpeg",
                    UploadedDate = DateTime.Today,
                    ImageTakenOnDate = DateTime.Today
                },
                new Image {
                    AlbumId = 3,
                    Title = "Twister",
                    Description = "Twister in USA",
                    ImageFile = getFileBytes("\\Content\\Images\\Photography\\05.jpg"),
                    ImageMimeType = "image/jpeg",
                    UploadedDate = DateTime.Today,
                    ImageTakenOnDate = DateTime.Today
                }
            };

            images.ForEach(s => context.Images.Add(s));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment {
                    ImageID = 1,
                    Subject = "Glacier point",
                    Body = "On a cold morning on top of Glacier point at Yosemite."
                },
                new Comment {
                    ImageID = 1,
                    Subject = "Brrrrr",
                    Body = "Yeah, it was cold!"
                },
                new Comment {
                    ImageID = 2,
                    Subject = "Awesome",
                    Body = "Completely inspiring."
                },
                new Comment {
                    ImageID = 3,
                    Subject = "Exploration",
                    Body = "Mankinds curiosity holds no bounds."
                },
                new Comment {
                    ImageID = 4,
                    Subject = "In a galaxy, far far away....",
                    Body = "Amazing to think we are seeing something as it was billions of years ago!"
                }
            };

            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();
        }
    }
}