using System.Web.Mvc;

namespace SiriusApplication.Areas.Cycling.Controllers
{
    using SiriusApplication.Utils;

    public class CyclingController : Controller
    {
        [ValueReporter]
        [HandleError(View = "Error")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
