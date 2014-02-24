namespace SiriusApplication.Models
{
    using System.Linq;

    public interface IImageRepository
    {
        IQueryable<Image> Images { get; }

        Image FindImageById(int id);
    }
}