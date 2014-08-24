namespace SiriusTests.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using SiriusApplication.Models;

    class MockImageRepository : IImageRepository
    {
        private List<Image> _mockDB = new List<Image>(); 




        public IQueryable<Image> Images { get; private set; }

        public Image GetImageById(int id)
        {
            return _mockDB.FirstOrDefault(x => x.ImageId == id);
        }








        public Image GetImageByTitle(string title)
        {
            throw new System.NotImplementedException();
        }

        public Image GetDefaultImageWhenNoImageFound()
        {
            throw new System.NotImplementedException();
        }

        public List<Image> GetAllImagesOrderedDescending()
        {
            throw new System.NotImplementedException();
        }

        public List<Image> GetImagesOrderedDescending(int number)
        {
            throw new System.NotImplementedException();
        }

        public List<Image> GetImagesByAlbumId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
