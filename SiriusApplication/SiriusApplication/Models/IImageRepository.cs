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

        List<Image> GetAllImagesOrderedDescending();

        List<Image> GetImagesOrderedDescending(int number);

        List<Image> GetImagesByAlbumId(int id);
    }
}