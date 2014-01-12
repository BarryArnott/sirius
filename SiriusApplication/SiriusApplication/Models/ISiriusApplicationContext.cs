using System.Linq;

namespace SiriusApplication.Models
{
    public interface ISiriusApplicationContext
    {
        IQueryable<Image> Images { get; }
        IQueryable<Comment> Comments { get; }
        IQueryable<Album> Albums { get; }

        int SaveChanges();
        T Add<T>(T entity) where T : class;
        Album FindAlbumById(int ID);
        Album FindAlbumByTitle(string Title);
        Image FindImageById(int ID);
        Image FindImageByTitle(string Title);
        Image FindDefaultImageWhenNoImageFound();
        Album FindAlbumCoverImageById(int ID);
        Comment FindCommentById(int ID);
        T Delete<T>(T entity) where T : class;
    }
}
