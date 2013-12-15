using System.Web.Mvc;
using AspNet.NoMvc.Mvc2;

namespace AspNet.NoMvcAndTinyController.Sample.Products
{
    [HandleError]
    public class BrowseController : NoMvcTinyController
    {
        public ActionResult Get()
        {
            var model = new IndexModel { Message = "Welcome to ASP.NET MVC!" };
            return View(model);
        }
    }
}