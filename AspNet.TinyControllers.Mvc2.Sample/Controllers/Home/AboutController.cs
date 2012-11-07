using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc2.Sample.Controllers.Home
{
    [HandleError]
    public class AboutController : TinyController
	{
		public ViewResult Get()
		{
			return View();
		}
	}
}