﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void Test_DisplayAll_Return_View()
        {
            var context = new FakeSiriusContext();
            var controller = new ImageController(context);
            var result = controller.DisplayAll() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_DisplayById_Return_View()
        {
            var context = new FakeSiriusContext
                {
                    Images = new[]
                        {
                            new Image {ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg"}
                        }.AsQueryable()
                };
            var controller = new ImageController(context);
            var result = controller.DisplayById(1) as ViewResult;

            Assert.AreEqual("DisplaySpecific", result.ViewName);
        }

        [TestMethod]
        public void Test_DisplayById_Model_Type()
        {
            var context = new FakeSiriusContext
            {
                Images = new[]
                        {
                            new Image{ ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg" },
                            new Image{ ImageId = 2, ImageFile = new byte[1], ImageMimeType = "image/jpeg" }
                        }.AsQueryable()
            };

            var controller = new ImageController(context);
            var result = controller.DisplayById(1) as ViewResult;

            Assert.AreEqual(typeof(Image), result.Model.GetType());
        }

        [TestMethod]
        public void Test_DisplayById()
        {
            var context = new FakeSiriusContext
            {
                Images = new[]
                        {
                            new Image{ ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test1" },
                            new Image{ ImageId = 2, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test2" }
                        }.AsQueryable()
            };

            var controller = new ImageController(context);
            var result = controller.DisplayById(1) as ViewResult;
            var modelImage = (Image)result.ViewData.Model;

            Assert.AreEqual("Test1", modelImage.Title);
        }

        [TestMethod]
        public void Test_DisplayByTitle_Return_View()
        {
            var context = new FakeSiriusContext
            {
                Images = new[]
                        {
                            new Image {ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test1"}
                        }.AsQueryable()
            };
            var controller = new ImageController(context);
            var title = "Test1";
            var result = controller.DisplayByTitle(title) as ViewResult;

            Assert.AreEqual("DisplaySpecific", result.ViewName);
        }

        [TestMethod]
        public void Test_DisplayByTitle_Model_Type()
        {
            var context = new FakeSiriusContext
            {
                Images = new[]
                        {
                            new Image{ ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test1" },
                            new Image{ ImageId = 2, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test1" }
                        }.AsQueryable()
            };

            var controller = new ImageController(context);
            var title = "Test1";
            var result = controller.DisplayByTitle(title) as ViewResult;

            Assert.AreEqual(typeof(Image), result.Model.GetType());
        }

        [TestMethod]
        public void Test_DisplayByTitle()
        {
            var context = new FakeSiriusContext
            {
                Images = new[]
                        {
                            new Image{ ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test1" },
                            new Image{ ImageId = 2, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test2" }
                        }.AsQueryable()
            };

            var controller = new ImageController(context);
            var title = "Test1";
            var result = controller.DisplayByTitle(title) as ViewResult;
            var modelImage = (Image)result.ViewData.Model;

            Assert.AreEqual("Test1", modelImage.Title);
        }

        [TestMethod]
        public void Test_Delete_Return_View()
        {
            var context = new FakeSiriusContext
            {
                Images = new[]
                        {
                            new Image {ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test1"}
                        }.AsQueryable()
            };
            var controller = new ImageController(context);
            var result = controller.Delete(1) as ViewResult;

            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void Test_Delete_Model_Type()
        {
            var context = new FakeSiriusContext
            {
                Images = new[]
                        {
                            new Image{ ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test1" },
                            new Image{ ImageId = 2, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test1" }
                        }.AsQueryable()
            };

            var controller = new ImageController(context);
            var result = controller.Delete(1) as ViewResult;

            Assert.AreEqual(typeof(Image), result.Model.GetType());
        }

        [TestMethod]
        public void Test_Delete()
        {
            var context = new FakeSiriusContext
            {
                Images = new[]
                        {
                            new Image{ ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test1" },
                            new Image{ ImageId = 2, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test2" }
                        }.AsQueryable()
            };

            var controller = new ImageController(context);
            var result = controller.Delete(1) as ViewResult;
            var modelImage = (Image)result.ViewData.Model;

            Assert.AreEqual("Test1", modelImage.Title);
        }

        [TestMethod]
        public void Test_DeleteConfirmed_Return_View()
        {
            var context = new FakeSiriusContext
            {
                Images = new[]
                        {
                            new Image {ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test1"},
                            new Image {ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg", Title = "Test2"}
                        }.AsQueryable()
            };
            var controller = new ImageController(context);
            var result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }
        
        [TestMethod]
        public void Test_GetImage_Return_Type()
        {
            var context = new FakeSiriusContext();

            context.Images = new[] {
                new Image{ ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/jpeg" },
                new Image{ ImageId = 2, ImageFile = new byte[1], ImageMimeType = "image/jpeg" },
                new Image{ ImageId = 3, ImageFile = new byte[1], ImageMimeType = "image/jpeg" },
                new Image{ ImageId = 4, ImageFile = new byte[1], ImageMimeType = "image/jpeg" },
            }.AsQueryable();

            var controller = new ImageController(context);
            var result = controller.GetImage(1);

            Assert.AreEqual(typeof(FileContentResult), result.GetType());
        }

        [TestMethod]
        public void Test_GetImage()
        {
            var context = new FakeSiriusContext();

            context.Images = new[] {
                new Image{ ImageId = 1, ImageFile = new byte[1], ImageMimeType = "image/raw" },
                new Image{ ImageId = 2, ImageFile = new byte[1], ImageMimeType = "image/png" },
                new Image{ ImageId = 3, ImageFile = new byte[1], ImageMimeType = "image/jpeg" },
                new Image{ ImageId = 4, ImageFile = new byte[1], ImageMimeType = "image/bmp" },
            }.AsQueryable();

            var controller = new ImageController(context);
            var result = controller.GetImage(3);

            Assert.AreEqual("image/jpeg", result.ContentType);
        }
    }
}
