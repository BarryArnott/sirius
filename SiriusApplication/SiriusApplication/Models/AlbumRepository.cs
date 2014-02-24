namespace SiriusApplication.Models
{
    using System.Linq;

    public class AlbumRepository : IAlbumRepository
    {
        private ISiriusApplicationContext _context;

        public AlbumRepository(ISiriusApplicationContext context)
        {
            this._context = context;
        }

        public AlbumRepository()
        {
            this._context = new SiriusApplicationContext();
        }

        public IQueryable<Album> Albums
        {
            get { return this._context.Albums; }
        }

        public IQueryable<Image> Images
        {
            get { return this._context.Images; }
        }

        public Album FindAlbumCoverImageById(int id)
        {
            return this._context.Albums.Find(id);
        }

        public Image FindDefaultImageWhenNoImageFound()
        {
            //The default image id
            const int noImageFound = 1;

            return _context.Images.Find(noImageFound);
        }
    }
}