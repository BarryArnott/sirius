namespace SiriusApplication.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IImageRepository
    {
        IQueryable<Image> Images { get; }

        Image GetImageById(int id);

        Image GetImageByTitle(string title);

        Image GetDefaultImageWhenNoImageFound();

        List<Image> GetOrderedImagesDescending(int number);
    }
}