using System.Web.Mvc;

namespace SiriusApplication.Areas.About.Controllers
{
    using SiriusApplication.Utils;

    public class AboutController : Controller
    {
        [ValueReporter]
        [HandleError(View = "Error")]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
