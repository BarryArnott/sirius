using System.Web.Mvc;
using SiriusApplication.Utils;

namespace SiriusApplication.Controllers
{
    [ValueReporter]
    [HandleError(View = "Error")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

    }
}
