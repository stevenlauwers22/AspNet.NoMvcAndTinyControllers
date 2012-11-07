using System.Web.Mvc;
using AspNet.TinyControllers.Mvc2;

namespace AspNet.NoMvcAndTinyController.Sample.Home
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