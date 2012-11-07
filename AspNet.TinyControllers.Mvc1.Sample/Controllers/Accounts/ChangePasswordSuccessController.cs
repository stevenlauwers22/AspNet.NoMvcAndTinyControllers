using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc1.Sample.Controllers.Accounts
{
    [HandleError]
    public class ChangePasswordSuccessController : TinyController
	{
		public ActionResult Get()
		{
			return View();
		}
	}
}