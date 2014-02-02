﻿using System.Web.Mvc;

namespace SiriusApplication.Areas.About
{
    public class AboutAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "About";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "About_default",
                "About/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}