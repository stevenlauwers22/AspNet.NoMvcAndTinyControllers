using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc3.Sample.Areas.Forum.Controllers
{
	[HandleError]
    public class HomeController : Controller
	{
		public ActionResult Index()
		{
            return View();
		}
	}
}