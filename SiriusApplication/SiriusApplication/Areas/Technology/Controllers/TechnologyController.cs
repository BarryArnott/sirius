using System.Web.Mvc;

namespace SiriusApplication.Areas.Technology.Controllers
{
    using SiriusApplication.Utils;

    public class TechnologyController : Controller
    {
        [ValueReporter]
        [HandleError(View = "Error")]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
