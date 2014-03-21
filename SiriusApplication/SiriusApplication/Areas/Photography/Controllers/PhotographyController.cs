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
        public ActionResult _AlbumGallery(int number = 0)
        {
            List<Album> albums;
            if (number == 0)
            {
                // list all albums
                albums = _albumRepository.Albums.ToList();
            }
            else
            {
                albums = _albumRepository.GetOrderedAlbumsDescending(number);
            }

            return PartialView("_AlbumGallery", albums);
        }

        [ChildActionOnly]
        public ActionResult _ImageGallery(int number = 0)
        {
            List<Image> images;
            if (number == 0)
            {
                images = _imageRepository.Images.ToList();
            }
            else
            {
                images = _imageRepository.GetOrderedImagesDescending(number);
            }

            return PartialView("_ImageGallery", images);
        }

        //Required to retrieve album cover image for album display
        public FileContentResult GetAlbumCoverImageById(int id)
        {
            Album album = _albumRepository.GetAlbumCoverImageById(id);

            if (album == null)
            {
                album = _albumRepository.GetDefaultAlbumWhenNoAlbumFound();
                return File(album.AlbumCoverFile, album.AlbumCoverMimeType);
            }
            
            if (album.AlbumCoverFile == null)
            {
                Image image = this._imageRepository.GetDefaultImageWhenNoImageFound();

                album.AlbumCoverFile = image.ImageFile;
                album.AlbumCoverMimeType = image.ImageMimeType;

                return File(album.AlbumCoverFile, album.AlbumCoverMimeType);
            }

            return File(album.AlbumCoverFile, album.AlbumCoverMimeType);
        }

        public FileContentResult GetImage(int id)
        {
            try
            {
                Image image = _imageRepository.GetImageById(id);
                return File(image.ImageFile, image.ImageMimeType);
            }
            catch (Exception)
            {
                Image image = this._imageRepository.GetDefaultImageWhenNoImageFound();
                return this.File(image.ImageFile, image.ImageMimeType);
            }
        }
    }
}
