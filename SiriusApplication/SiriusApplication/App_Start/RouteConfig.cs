using System.Web.Mvc;
using System.Web.Routing;

namespace SiriusApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            AreaRegistration.RegisterAllAreas();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                //Register the namespace so default route hits ~Controllers/HomeController
                namespaces: new[] { "SiriusApplication.Controllers" });
        }
    }
}