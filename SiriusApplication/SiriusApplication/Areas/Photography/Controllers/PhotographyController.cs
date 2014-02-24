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

        public PhotographyController()
        {
            _albumRepository = new AlbumRepository();
        }

        public PhotographyController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
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
                albums = _albumRepository.Albums.ToList();
            }
            else
            {
                //TODO move out into albumrepository
                albums = (
                from p in _albumRepository.Albums
                orderby p.CreatedDate descending
                select p).Take(number).ToList();
            }

            return PartialView("_AlbumGallery", albums);
        }

        [ChildActionOnly]
        public ActionResult _ImageGallery(int number = 0)
        {
            List<Image> images;
            if (number == 0)
            {
                images = _albumRepository.Images.ToList();
            }
            else
            {
                //TODO move out into imagerepository
                images = (
                from p in _albumRepository.Images
                orderby p.UploadedDate descending
                select p).Take(number).ToList();
            }

            return PartialView("_ImageGallery", images);
        }

        //Required to retrieve album cover image for album display
        public FileContentResult GetAlbumCoverImage(int id)
        {
            try
            {
                Album album = _albumRepository.FindAlbumCoverImageById(id);

                if (album != null)
                {
                    return File(album.AlbumCoverFile, album.AlbumCoverMimeType);
                }
                else
                {
                    Image image = _albumRepository.FindDefaultImageWhenNoImageFound();

                    return File(image.ImageFile, image.ImageMimeType);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
