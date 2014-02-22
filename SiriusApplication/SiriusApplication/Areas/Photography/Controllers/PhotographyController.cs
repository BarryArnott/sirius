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
        private ISiriusApplicationContext context;

        // constructor
        public PhotographyController()
        {
            context = new SiriusApplicationContext();
        }

        // constructor. only used for testing or when a context is passed in
        public PhotographyController(ISiriusApplicationContext Context)
        {
            context = Context;
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
                albums = context.Albums.ToList();
            }
            else
            {
                albums = (
                from p in context.Albums
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
                images = context.Images.ToList();
            }
            else
            {
                images = (
                from p in context.Images
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
                Album album = context.FindAlbumCoverImageById(id);

                if (album != null)
                {
                    return File(album.AlbumCoverFile, album.AlbumCoverMimeType);
                }
                else
                {
                    Image image = context.FindDefaultImageWhenNoImageFound();

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
