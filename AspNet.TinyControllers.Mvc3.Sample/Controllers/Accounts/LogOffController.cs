using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc3.Sample.Controllers.Accounts
{
    [HandleError]
    public class LogOffController : TinyController
	{
		public ActionResult Get()
		{
            return RedirectToAction("Index", "Home");
		}
	}
}