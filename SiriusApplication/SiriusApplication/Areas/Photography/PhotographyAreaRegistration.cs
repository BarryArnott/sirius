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
            context.MapRoute(
                "Photography_default",
                "Photography/{controller}/{action}/{id}",
                new { controller = "Photography", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
