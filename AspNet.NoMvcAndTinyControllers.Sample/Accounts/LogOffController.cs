using System.Web.Mvc;
using AspNet.TinyControllers.Mvc2;

namespace AspNet.NoMvcAndTinyController.Sample.Accounts
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