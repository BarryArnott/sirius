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
                    AlbumID = 1,
                    Title = "Default Images",
                    Description = "Default Images",
                    AlbumCoverFile = getFileBytes ("\\content\\images\\common-images\\no_album_image.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Album {
                    AlbumID = 2,
                    Title = "Album 2",
                    Description = "Yosemite",
                    AlbumCoverFile = getFileBytes ("\\content\\images\\photography\\01.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Album {
                    AlbumID = 3,
                    Title = "Album 3",
                    Description = "Space",
                    AlbumCoverFile = getFileBytes ("\\content\\images\\photography\\02.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Album {
                    AlbumID = 4,
                    Title = "Album 4",
                    Description = "Storms",
                    AlbumCoverFile = getFileBytes ("\\content\\images\\photography\\05.jpg"),
                    AlbumCoverMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                }
            };

            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();

            var images = new List<Image>
            {
                new Image {
                    AlbumID = 1,
                    Title = "No Image Found",
                    Description = "No Image Found",
                    ImageFile = getFileBytes ("\\content\\images\\common-images\\no_album_image.jpg"),
                    ImageMimeType ="image/gif",
                    CreatedDate = DateTime.Today
                },
                new Image {
                    AlbumID = 2,
                    Title = "Yosemite",
                    Description = "Yosemite 2011",
                    ImageFile = getFileBytes ("\\content\\images\\photography\\01.jpg"),
                    ImageMimeType ="image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Image {
                    AlbumID = 3,
                    Title = "Space Shuttle",
                    Description = "Launch of the space shuttle",
                    ImageFile = getFileBytes ("\\content\\images\\photography\\02.jpg"),
                    ImageMimeType ="image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Image {
                    AlbumID = 3,
                    Title = "Opportunity",
                    Description = "Opportunity rover on Mars",
                    ImageFile = getFileBytes ("\\content\\images\\photography\\03.jpg"),
                    ImageMimeType ="image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Image {
                    AlbumID = 3,
                    Title = "Hubble",
                    Description = "Hubble Deep Field",
                    ImageFile = getFileBytes ("\\content\\images\\photography\\04.jpg"),
                    ImageMimeType ="image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Image {
                    AlbumID = 4,
                    Title = "Twister",
                    Description = "Twister in USA",
                    ImageFile = getFileBytes ("\\content\\images\\photography\\05.jpg"),
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
        }
    }
}