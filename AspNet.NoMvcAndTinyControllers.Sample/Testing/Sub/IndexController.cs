using System.Web.Mvc;
using AspNet.TinyControllers.Mvc2;

namespace AspNet.NoMvcAndTinyController.Sample.Testing.Sub
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