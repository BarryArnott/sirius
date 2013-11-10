using System;
using System.Collections.Generic;
using System.Linq;
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
                    Title = "Test Photo",
                    Description = "Your Description",
                    ImageFile = getFileBytes("\\Content\\Images\\01.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                }
            };

            images.ForEach(s => context.Images.Add(s));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment {
                    ImageID = 1,
                    Subject = "Test Comment",
                    Body = "This comment " + "should appear in " + "photo 1"
                }
            };

            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();
        }
    }
}