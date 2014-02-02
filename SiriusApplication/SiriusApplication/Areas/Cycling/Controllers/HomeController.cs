using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiriusApplication.Areas.Cycling.Controllers
{
    using SiriusApplication.Utils;

    public class HomeController : Controller
    {
        [ValueReporter]
        [HandleError(View = "Error")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
