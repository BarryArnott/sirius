namespace SiriusApplication.Models
{
    using System.Collections.Generic;
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

        public Album GetAlbumById(int id)
        {
            return this._context.Albums.Find(id);
        }

        public List<Album> GetAllAlbumsOrderedDescending()
        {
            List<Album> albums;

            albums = (
                from p in this._context.Albums
                where p.Title != "No Album Found"
                orderby p.CreatedDate descending
                select p).ToList();

            return albums;
        }

        public List<Album> GetAlbumsOrderedDescending(int number)
        {
            List<Album> albums;

            albums = (
                from p in this._context.Albums
                where p.Title != "No Album Found"
                orderby p.CreatedDate descending
                select p).Take(number).ToList();

            return albums;
        }

        public Album GetAlbumByTitle(string Title)
        {
            Album album = (from p in _context.Albums
                           where p.Title == Title
                           select p).FirstOrDefault();
            return album;
        }

        public Album GetDefaultAlbumWhenNoAlbumFound()
        {
            string defaultAlbumTitle = "No Album Found";

            return GetAlbumByTitle(defaultAlbumTitle);
        }
    }
}