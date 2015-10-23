using System.Web.Mvc;
using AspNet.NoMvc.Mvc2;

namespace AspNet.NoMvcAndTinyControllers.Sample.Accounts
{
	[HandleError]
    public class IndexController : NoMvcTinyController
	{
		public ActionResult Get()
		{
            return View();
		}
	}
}