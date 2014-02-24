using System.Web.Mvc;

namespace SiriusApplication.Areas.Contact.Controllers
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
