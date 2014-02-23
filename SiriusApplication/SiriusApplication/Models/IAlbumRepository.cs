namespace SiriusApplication.Models
{
    using System.Linq;

    public interface IAlbumRepository
    {
        IQueryable<Album> Albums { get; }

        IQueryable<Image> Images { get; }

        Album FindAlbumCoverImageById(int ID);

        Image FindDefaultImageWhenNoImageFound();
    }
}