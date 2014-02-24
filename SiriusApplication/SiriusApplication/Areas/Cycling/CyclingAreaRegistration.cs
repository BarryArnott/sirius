using System.Web.Mvc;

namespace SiriusApplication.Areas.Cycling
{
    public class CyclingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Cycling";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Cycling_default",
                "Cycling/{controller}/{action}/{id}",
                new { controller = "Cycling", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
