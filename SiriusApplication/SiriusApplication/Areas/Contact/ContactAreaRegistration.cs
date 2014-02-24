﻿using System.Web.Mvc;

namespace SiriusApplication.Areas.Contact
{
    public class ContactAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Contact";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Contact_default",
                "Contact/{controller}/{action}/{id}",
                new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
