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

            var images = new List<Image>
            {
                new Image {
                    AlbumID = 1,
                    Title = "Yosemite",
                    Description = "Yosemite 2011",
                    ImageFile = getFileBytes ("\\Content\\Images\\01.jpg"),
                    ImageMimeType ="image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Image {
                    AlbumID = 1,
                    Title = "Space Shuttle",
                    Description = "Launch of the space shuttle",
                    ImageFile = getFileBytes ("\\Content\\Images\\02.jpg"),
                    ImageMimeType ="image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Image {
                    AlbumID = 2,
                    Title = "Opportunity",
                    Description = "Opportunity rover on Mars",
                    ImageFile = getFileBytes ("\\Content\\Images\\03.jpg"),
                    ImageMimeType ="image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Image {
                    AlbumID = 2,
                    Title = "Hubble",
                    Description = "Hubble deep field",
                    ImageFile = getFileBytes ("\\Content\\Images\\04.jpg"),
                    ImageMimeType ="image/jpeg",
                    CreatedDate = DateTime.Today
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

            var albums = new List<Album>
            {
                new Album {
                    AlbumID = 1,
                    Title = "Album 1",
                    Description = "Yosemite and Space Shuttle",
                    CreatedDate = DateTime.Today
                },
                new Album {
                    AlbumID = 2,
                    Title = "Album 2",
                    Description = "Opportunity and Hubble",
                    CreatedDate = DateTime.Today
                }
            };

            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();
        }
    }
}