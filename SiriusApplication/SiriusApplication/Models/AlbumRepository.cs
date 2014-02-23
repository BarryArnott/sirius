namespace SiriusApplication.Models
{
    using System.Diagnostics.CodeAnalysis;
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


        IQueryable<Album> IAlbumRepository.Albums
        {
            get { return this._context.Albums; }
        }

        IQueryable<Image> IAlbumRepository.Images
        {
            get { return this._context.Images; }
        }

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        Album IAlbumRepository.FindAlbumCoverImageById(int id)
        {
            return this._context.Albums.Find(id);
        }

        Image IAlbumRepository.FindDefaultImageWhenNoImageFound()
        {
            //The default image id
            const int noImageFound = 1;

            return _context.Images.Find(noImageFound);
        }
    }
}