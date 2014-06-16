namespace SiriusApplication.Models
{
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

        public List<Image> GetAllImagesOrderedDescending()
        {
            List<Image> images = (
                              from p in this._context.Images
                              where p.Title != "No Image Found"
                              orderby p.UploadedDate descending
                              select p).ToList();

            return images;
        }

        public List<Image> GetImagesOrderedDescending(int number)
        {
            List<Image> images = (
                              from p in this._context.Images
                              where p.Title != "No Image Found"
                              orderby p.UploadedDate descending
                              select p).Take(number).ToList();

            return images;
        }

        public List<Image> GetImagesByAlbumId(int id)
        {
            List<Image> images = (
                                from p in this._context.Images
                                where p.AlbumId == id
                                orderby p.UploadedDate descending
                                select p).ToList();
            return images;
        }
    }
}