using System.Web.Mvc;
using AspNet.TinyControllers.Mvc2;

namespace AspNet.NoMvcAndTinyController.Sample.Accounts
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