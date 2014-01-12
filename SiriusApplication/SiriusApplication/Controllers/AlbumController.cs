using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SiriusApplication.Models;
using SiriusApplication.Utils;

namespace SiriusApplication.Controllers
{

    [ValueReporter]
    [HandleError(View = "Error")]
    public class AlbumController : Controller
    {
        private ISiriusApplicationContext context;

        // constructor
        public AlbumController ()
        {
            context = new SiriusApplicationContext();
        }

        // constructor. only used for testing or when a context is passed in
        public AlbumController (ISiriusApplicationContext Context)
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











        //
        // GET: /Album/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Album album = db.Albums.Find(id);
        //    if (album == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(album);
        //}

        ////
        //// GET: /Album/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //////
        ////// POST: /Album/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Album album)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Albums.Add(album);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(album);
        //}

        ////
        //// GET: /Album/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Album album = db.Albums.Find(id);
        //    if (album == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(album);
        //}

        ////
        //// POST: /Album/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Album album)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(album).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(album);
        //}

        ////
        //// GET: /Album/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Album album = db.Albums.Find(id);
        //    if (album == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(album);
        //}

        ////
        //// POST: /Album/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Album album = db.Albums.Find(id);
        //    db.Albums.Remove(album);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}