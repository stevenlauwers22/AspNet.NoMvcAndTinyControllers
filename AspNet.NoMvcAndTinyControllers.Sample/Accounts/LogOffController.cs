using System.Web.Mvc;
using AspNet.NoMvc.Mvc2;

namespace AspNet.NoMvcAndTinyController.Sample.Accounts
{
    [HandleError]
    public class LogOffController : NoMvcTinyController
	{
		public ActionResult Get()
		{
            return RedirectToAction("Index", "Home");
		}
	}
}