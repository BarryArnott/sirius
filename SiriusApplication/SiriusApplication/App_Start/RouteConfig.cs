using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SiriusApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            ////This route means we can access photos like this: /Photography/3
            //routes.MapRoute(
            //    name: "ImageIdRoute",
            //    url: "Photography/{id}",
            //    defaults: new { controller = "Image", action = "DisplayById" },
            //    constraints: new { id = "[0-9]+" }
            //);

            ////This route means we can access photos like this: /Photography/title/my%20photo%20title
            //routes.MapRoute(
            //    name: "ImageTitleRoute",
            //    url: "Photography/title/{title}",
            //    defaults: new { controller = "Image", action = "DisplayByTitle" }
            //);

            ////This route means we can access photos like this: /Photography/title/my%20photo%20title
            //routes.MapRoute(
            //    name: "ImageIndexRoute",
            //    url: "Photography/",
            //    defaults: new { controller = "Image", action = "Index" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                //Register the namespace so default route hits ~Controllers/HomeController
                namespaces: new[] { "SiriusApplication.Controllers" });
        }
    }
}