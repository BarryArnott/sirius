using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using SiriusApplication.Models;
using SiriusApplication.Utils;

namespace SiriusApplication.Areas.Photography.Controllers
{
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
            ViewBag.AlbumShowcaseTitle = "Latest Albums";

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
            ViewBag.ImageShowcaseTitle = "Latest Photos";

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

        [ChildActionOnly]
        public ActionResult _GoogleMaps(int id, int count)
        {
            Image image = _imageRepository.GetImageById(id);

            ViewBag.Increment = count;

            return PartialView("_GoogleMaps", image);
        }

        [ChildActionOnly]
        public ActionResult _AlbumImageShowcase(int id, int pageNumber)
        {
            //This should never be greater than 10 as the _GoogleMaps view can only display 10 Google Map api's
            int numberOfImagesPerPage = 3;

            Album album = _albumRepository.GetAlbumById(id);
            ViewBag.ImageShowcaseTitle = "All photos for the album: " + album.Title;
            ViewBag.CurrentAlbumId = id;

            List<Image> images = this._imageRepository.GetImagesByAlbumId(id);

            return PartialView("_AlbumImageShowcase", images.ToPagedList(pageNumber, numberOfImagesPerPage));
        }

        //Required to retrieve album cover thumbnail image for album display
        public FileContentResult DisplayAlbumCoverThumbnailImageFileById(int id)
        {
            Album album = _albumRepository.GetAlbumById(id);

            if (album.AlbumCoverFile == null)
            {
                Image defaultImage = this._imageRepository.GetDefaultImageWhenNoImageFound();

                album.AlbumCoverFile = defaultImage.ImageFileThumbnail;
                album.AlbumCoverMimeType = defaultImage.ImageMimeType;

                // an albums cover file will always be a thumbnail
                return File(album.AlbumCoverFile, album.AlbumCoverMimeType);
            }

            return File(album.AlbumCoverFile, album.AlbumCoverMimeType);
        }

        public FileContentResult DisplayThumbnailImageFileById(int id)
        {
            Image image = _imageRepository.GetImageById(id);

            // image can be found but no associated photo
            if (image.ImageFileThumbnail == null)
            {
                Image defaultImage = _imageRepository.GetDefaultImageWhenNoImageFound();

                image.ImageFileThumbnail = defaultImage.ImageFileThumbnail;
                image.ImageMimeType = defaultImage.ImageMimeType;

                return File(image.ImageFileThumbnail, image.ImageMimeType);
            }

            return File(image.ImageFileThumbnail, image.ImageMimeType);
        }

        public FileContentResult DisplayLargeImageFileById(int id)
        {
            Image image = _imageRepository.GetImageById(id);

            // image can be found but no associated photo
            if (image.ImageFileLarge == null)
            {
                Image defaultImage = _imageRepository.GetDefaultImageWhenNoImageFound();

                image.ImageFileLarge = defaultImage.ImageFileLarge;
                image.ImageMimeType = defaultImage.ImageMimeType;

                return File(image.ImageFileLarge, image.ImageMimeType);
            }

            return File(image.ImageFileLarge, image.ImageMimeType);
        }

        [HttpGet]
        public ActionResult DisplayImageById(int id)
        {
            Image image = _imageRepository.GetImageById(id);

            return PartialView("_ImageDetails", image);
        }

        public ActionResult DisplayAlbumById(int id, int? pageNumber)
        {
            ViewBag.PageNumber = pageNumber ?? 1;

            Album album = _albumRepository.GetAlbumById(id);

            return View("Album", album);
        }
    }
}
