namespace SiriusApplication.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IAlbumRepository
    {
        IQueryable<Album> Albums { get; }

        Album GetAlbumCoverImageById(int ID);

        List<Album> GetOrderedAlbumsDescending(int number);

        Album GetAlbumByTitle(string Title);

        Album GetDefaultAlbumWhenNoAlbumFound();

        //Image GetDefaultImageWhenNoImageFound();
    }
}