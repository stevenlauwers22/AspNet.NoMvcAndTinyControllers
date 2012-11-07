using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc4.Sample.Areas.Forum.Controllers
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