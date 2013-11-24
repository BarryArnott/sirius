﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiriusApplication.Models;
using SiriusApplication.Utils;

namespace SiriusApplication.Controllers
{
    [ValueReporter]
    [HandleError(View = "Error")]
    public class ImageController : Controller
    {
        private ISiriusApplicationContext context;

        // constructor
        public ImageController ()
        {
            context = new SiriusApplicationContext();
        }

        // constructor. only used for testing or when a context is passed in
        public ImageController (ISiriusApplicationContext Context)
        {
            context = Context;
        }

        public ActionResult Index()
        {
            return View("Index");
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
                orderby p.CreatedDate descending
                select p).Take(number).ToList();
            }

            return PartialView("_ImageGallery", images);
        }

        public ActionResult Display (int id)
        {
            Image image = context.FindImageById(id);

            if (image == null)
            {
                return HttpNotFound();
            }

            return View("Display", image);
        }

        public ActionResult DisplayByTitle(string title)
        {
            Image image = context.FindImageByTitle(title);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View("Display", image);
        }

        public ActionResult Create()
        {
            Image newPhoto = new Image();
            newPhoto.CreatedDate = DateTime.Today;

            return View("Create", newPhoto);
        }

        [HttpPost]
        public ActionResult Create(Image photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;

            if (!ModelState.IsValid)
            {
                return View("Create", photo);
            }
            else
            {
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.ImageFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.ImageFile, 0, image.ContentLength);
                }
            }

            context.Add<Image>(photo);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Image image = context.FindImageById(id);

            if (image == null)
            {
                return HttpNotFound();
            }

            return View("Delete", image);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = context.FindImageById(id);

            context.Delete<Image>(image);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            Image image = context.FindImageById(id);

            if (image != null)
            {
                return File(image.ImageFile, image.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult SlideShow()
        {
            throw new NotImplementedException("The SlideShow action is not yet ready");
        }
    }
}