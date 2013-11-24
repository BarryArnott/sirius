using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using SiriusApplication.Models;
using SiriusApplication.Controllers;
using System.Linq;
using SiriusTests.Mocks;

namespace SiriusTests
{
    [TestClass]
    public class ImageControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            var context = new FakeSiriusContext();
            var controller = new ImageController(context);
            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_ImageGallery_Model_Type()
        {
            var context = new FakeSiriusContext();

            context.Images = new[] {
                new Image(),
                new Image(),
                new Image(),
                new Image()
            }.AsQueryable();

            var controller = new ImageController(context);
            var result = controller._ImageGallery() as PartialViewResult;

            Assert.AreEqual(typeof(List<Image>), result.Model.GetType());
        }

        [TestMethod]
        public void Test_GetImage_Return_Type()
        {
            var context = new FakeSiriusContext();

            context.Images = new[] {
                new Image{ ImageID = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg" },
                new Image{ ImageID = 2, ImageFile = new byte[1], ImageMimeType = "image/jpeg" },
                new Image{ ImageID = 3, ImageFile = new byte[1], ImageMimeType = "image/jpeg" },
                new Image{ ImageID = 4, ImageFile = new byte[1], ImageMimeType = "image/jpeg" },
            }.AsQueryable();

            var controller = new ImageController(context);
            var result = controller.GetImage(1) as ActionResult;

            Assert.AreEqual(typeof(FileContentResult), result.GetType());
        }

        [TestMethod]
        public void Test_ImageGallery_No_Parameter()
        {
            var context = new FakeSiriusContext();
            context.Images = new[] {
                new Image(),
                new Image(),
                new Image(),
                new Image()
            }.AsQueryable();

            var controller = new ImageController(context);
            var result = controller._ImageGallery() as PartialViewResult;
            var modelPhotos = (IEnumerable<Image>)result.Model;

            Assert.AreEqual(4, modelPhotos.Count());
        }

        [TestMethod]
        public void Test_ImageGallery_Int_Parameter()
        {
            var context = new FakeSiriusContext();
            context.Images = new[] {
                new Image(),
                new Image(),
                new Image(),
                new Image()
            }.AsQueryable();

            var controller = new ImageController(context);
            var result = controller._ImageGallery(3) as PartialViewResult;
            var modelPhotos = (IEnumerable<Image>)result.Model;

            Assert.AreEqual(3, modelPhotos.Count());
        }
    }
}
