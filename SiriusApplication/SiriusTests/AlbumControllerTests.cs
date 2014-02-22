//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;
//using System.Web.Mvc;
//using SiriusApplication.Models;
//using SiriusApplication.Controllers;
//using System.Linq;
//using SiriusTests.Mocks;

//namespace SiriusTests
//{
//    [TestClass]
//    public class AlbumControllerTests
//    {
//        [TestMethod]
//        public void Test_Index_Return_View()
//        {
//            var context = new FakeSiriusContext();
//            var controller = new AlbumController(context);
//            var result = controller.Index() as ViewResult;

//            Assert.AreEqual("Index", result.ViewName);
//        }

//        [TestMethod]
//        public void Test_AlbumGallery_Model_Type()
//        {
//            var context = new FakeSiriusContext
//            {
//                Albums = new[]
//                        {
//                            new Album(),
//                            new Album(),
//                            new Album(),
//                            new Album(),
//                        }.AsQueryable()
//            };

//            var controller = new AlbumController(context);
//            var result = controller._AlbumGallery() as PartialViewResult;

//            Assert.AreEqual(typeof(List<Album>), result.Model.GetType());
//        }

//        [TestMethod]
//        public void Test_AlbumGallery_No_Parameter()
//        {
//            var context = new FakeSiriusContext
//            {
//                Albums = new[]
//                        {
//                            new Album(),
//                            new Album(),
//                            new Album(),
//                            new Album(),
//                            new Album()
//                        }.AsQueryable()
//            };

//            var controller = new AlbumController(context);
//            var result = controller._AlbumGallery() as PartialViewResult;
//            var modelAlbums = (IEnumerable<Album>)result.Model;

//            Assert.AreEqual(5, modelAlbums.Count());
//        }

//        [TestMethod]
//        public void Test_AlbumGallery_Int_Parameter()
//        {
//            var context = new FakeSiriusContext
//            {
//                Albums = new[]
//                        {
//                            new Album(),
//                            new Album(),
//                            new Album(),
//                            new Album(),
//                            new Album()
//                        }.AsQueryable()
//            };

//            var controller = new AlbumController(context);
//            var result = controller._AlbumGallery(3) as PartialViewResult;
//            var modelAlbums = (IEnumerable<Album>)result.Model;

//            Assert.AreEqual(3, modelAlbums.Count());
//        }

//        [TestMethod]
//        public void Test_GetAlbumCoverImage_Return_Type()
//        {
//            var context = new FakeSiriusContext();

//            context.Albums = new[] {
//                new Album{ AlbumId = 1, AlbumCoverFile = new byte[1], AlbumCoverMimeType = "image/raw"},
//                new Album{ AlbumId = 2, AlbumCoverFile = new byte[1], AlbumCoverMimeType = "image/png"},
//                new Album{ AlbumId = 3, AlbumCoverFile = new byte[1], AlbumCoverMimeType = "image/jpeg"},
//                new Album{ AlbumId = 4, AlbumCoverFile = new byte[1], AlbumCoverMimeType = "image/bmp"}

//            }.AsQueryable();

//            var controller = new AlbumController(context);
//            var result = controller.GetAlbumCoverImage(1);

//            Assert.AreEqual(typeof(FileContentResult), result.GetType());
//        }

//        [TestMethod]
//        public void Test_GetAlbumCoverImage_Int()
//        {
//            var context = new FakeSiriusContext();

//            context.Albums = new[] {
//                new Album{ AlbumId = 1, AlbumCoverFile = new byte[1], AlbumCoverMimeType = "image/raw"},
//                new Album{ AlbumId = 2, AlbumCoverFile = new byte[1], AlbumCoverMimeType = "image/png"},
//                new Album{ AlbumId = 3, AlbumCoverFile = new byte[1], AlbumCoverMimeType = "image/jpeg"},
//                new Album{ AlbumId = 4, AlbumCoverFile = new byte[1], AlbumCoverMimeType = "image/bmp"}
//            }.AsQueryable();

//            var controller = new AlbumController(context);
//            var result = controller.GetAlbumCoverImage(1);

//            Assert.AreEqual("image/raw", result.ContentType);
//        }
//    }
//}
