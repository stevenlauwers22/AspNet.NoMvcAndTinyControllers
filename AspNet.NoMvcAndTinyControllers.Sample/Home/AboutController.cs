using System.Web.Mvc;
using AspNet.NoMvc.Mvc2;

namespace AspNet.NoMvcAndTinyControllers.Sample.Home
{
    [HandleError]
    public class AboutController : NoMvcTinyController
    {
        public ActionResult Get()
        {
            return View();
        }
    }
}