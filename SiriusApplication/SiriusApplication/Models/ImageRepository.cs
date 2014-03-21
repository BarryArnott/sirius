namespace SiriusApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ImageRepository : IImageRepository
    {
        private ISiriusApplicationContext _context;

        public ImageRepository(ISiriusApplicationContext context)
        {
            this._context = context;
        }

        public ImageRepository()
        {
            this._context = new SiriusApplicationContext();
        }

        public IQueryable<Image> Images
        {
            get { return this._context.Images; }
        }

        public Image GetImageById(int id)
        {
            return this._context.Images.Find(id);
        }

        public Image GetImageByTitle(string title)
        {
            Image image = (from p in _context.Images
                           where p.Title == title
                           select p).FirstOrDefault();
            return image;
        }

        public Image GetDefaultImageWhenNoImageFound()
        {
            string defaultImageTitle = "No Image Found";

            return GetImageByTitle(defaultImageTitle);
        }

        public List<Image> GetOrderedImagesDescending(int number)
        {
            List<Image> images;
            
            images = (
                from p in this._context.Images
                orderby p.UploadedDate descending
                select p).Take(number).ToList();

            return images;
        }
    }
}