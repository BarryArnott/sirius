using System.Web.Mvc;

namespace SiriusApplication.Areas.Contact.Controllers
{
    using SiriusApplication.Utils;

    public class ContactController : Controller
    {
        [ValueReporter]
        [HandleError(View = "Error")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
