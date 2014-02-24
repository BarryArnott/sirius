using System.Web.Mvc;

namespace SiriusApplication.Areas.Technology
{
    public class TechnologyAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Technology";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Technology_default",
                "Technology/{controller}/{action}/{id}",
                new { controller = "Technology", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
