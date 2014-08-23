//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Web.Routing;
//using System.Web.Mvc;
//using SiriusTests.Mocks;
//using SiriusApplication;

//namespace SiriusTests
//{
//    [TestClass]
//    public class RoutingTests
//    {
//        [TestMethod]
//        public void Test_Default_Route_ControllerOnly()
//        {
//            var context = new FakeHttpContextForRouting(requestUrl: "~/ControllerName");
//            var routes = new RouteCollection();

//            RouteConfig.RegisterRoutes(routes);
//            RouteData routeData = routes.GetRouteData(context);

//            Assert.IsNotNull(routeData);
//            Assert.AreEqual("ControllerName", routeData.Values["controller"]);
//            Assert.AreEqual("Index", routeData.Values["action"]);
//        }

//        [TestMethod]
//        public void Test_Image_Route_With_ImageID()
//        {
//            var context = new FakeHttpContextForRouting(requestUrl: "~/Image/2");
//            var routes = new RouteCollection();

//            RouteConfig.RegisterRoutes(routes);
//            RouteData routeData = routes.GetRouteData(context);

//            Assert.IsNotNull(routeData);
//            Assert.AreEqual("Image", routeData.Values["controller"]);
//            Assert.AreEqual("DisplayById", routeData.Values["action"]);
//            Assert.AreEqual("2", routeData.Values["id"]);
//        }

//        [TestMethod]
//        public void Test_Image_Title_Route()
//        {
//            var context = new FakeHttpContextForRouting(requestUrl: "~/Image/title/Mars");
//            var routes = new RouteCollection();

//            RouteConfig.RegisterRoutes(routes);
//            RouteData routeData = routes.GetRouteData(context);

//            Assert.IsNotNull(routeData);
//            Assert.AreEqual("Image", routeData.Values["controller"]);
//            Assert.AreEqual("DisplayByTitle", routeData.Values["action"]);
//            Assert.AreEqual("Mars", routeData.Values["title"]);
//        }
//    }
//}
