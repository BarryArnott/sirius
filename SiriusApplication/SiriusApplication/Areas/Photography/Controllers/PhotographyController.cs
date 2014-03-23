using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SiriusApplication.Models;
using SiriusApplication.Utils;

namespace SiriusApplication.Areas.Photography.Controllers
{
    using System;

    [ValueReporter]
    [HandleError(View = "Error")]
    public class PhotographyController : Controller
    {
        private IAlbumRepository _albumRepository;

        private IImageRepository _imageRepository;

        public PhotographyController()
        {
            _albumRepository = new AlbumRepository();
            _imageRepository = new ImageRepository();
        }

        public PhotographyController(IAlbumRepository albumRepository, IImageRepository imageRepository)
        {
            _albumRepository = albumRepository;
            _imageRepository = imageRepository;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        [ChildActionOnly]
        public ActionResult _AlbumShowcase(int number = 0)
        {
            List<Album> albums;
            if (number == 0)
            {
                // list all albums
                albums = _albumRepository.GetAllAlbumsOrderedDescending();
            }
            else
            {
                albums = _albumRepository.GetAlbumsOrderedDescending(number);
            }

            return PartialView("_AlbumShowcase", albums);
        }

        [ChildActionOnly]
        public ActionResult _ImageShowcase(int number = 0)
        {
            List<Image> images;
            if (number == 0)
            {
                images = _imageRepository.GetAllImagesOrderedDescending();
            }
            else
            {
                images = _imageRepository.GetImagesOrderedDescending(number);
            }

            return PartialView("_ImageShowcase", images);
        }

        //Required to retrieve album cover image for album display
        public FileContentResult DisplayAlbumCoverImageFileById(int id)
        {
            Album album = _albumRepository.GetAlbumById(id);

            if (album.AlbumCoverFile == null)
            {
                Image defaultImage = this._imageRepository.GetDefaultImageWhenNoImageFound();

                album.AlbumCoverFile = defaultImage.ImageFile;
                album.AlbumCoverMimeType = defaultImage.ImageMimeType;

                return File(album.AlbumCoverFile, album.AlbumCoverMimeType);
            }

            return File(album.AlbumCoverFile, album.AlbumCoverMimeType);
        }

        public FileContentResult DisplayImageFileById(int id)
        {
            Image image = _imageRepository.GetImageById(id);

            // image can be found but no associated photo
            if (image.ImageFile == null)
            {
                Image defaultImage = _imageRepository.GetDefaultImageWhenNoImageFound();

                image.ImageFile = defaultImage.ImageFile;
                image.ImageMimeType = defaultImage.ImageMimeType;

                return File(image.ImageFile, image.ImageMimeType);
            }

            return File(image.ImageFile, image.ImageMimeType);
        }

        public ActionResult DisplayImageById(int id)
        {
            Image image = _imageRepository.GetImageById(id);

            return View("Image", image);
        }

        public ActionResult DisplayAlbumById(int id)
        {
            Album album = _albumRepository.GetAlbumById(id);

            return View("Album", album);
        }
    }
}
