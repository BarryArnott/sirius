using System.Web.Mvc;

namespace SiriusApplication.Areas.Photography
{
    public class PhotographyAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Photography";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // so we can navigate to specific album via /Photography/Album/5
            context.MapRoute(
                "AlbumIdRoute",
                "Photography/Album/{id}",
                new { controller = "Photography", action = "DisplayAlbumById" },
                constraints: new { id = "[0-9]+" }
            );

            // so we can navigate to specific image via /Photography/Image/5
            context.MapRoute(
                "ImageIdRoute",
                "Photography/Image/{id}",
                new { controller = "Photography", action = "DisplayImageById" },
                constraints: new { id = "[0-9]+" }
            );

            context.MapRoute(
                "Photography_default",
                "Photography/{controller}/{action}/{id}",
                defaults: new { controller = "Photography", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
