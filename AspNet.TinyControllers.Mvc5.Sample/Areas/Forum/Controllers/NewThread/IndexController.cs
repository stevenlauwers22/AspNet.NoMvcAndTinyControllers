using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc5.Sample.Areas.Forum.Controllers.NewThread
{
	[HandleError]
    public class IndexController : TinyController
	{
		public ActionResult Get()
		{
            return View();
		}
	}
}