namespace SiriusApplication.Models
{
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

        public Image FindImageById(int id)
        {
            return this._context.Images.Find(id);
        }
    }
}