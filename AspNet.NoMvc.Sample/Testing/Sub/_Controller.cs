using System.Web.Mvc;

namespace AspNet.NoMvc.Sample.Testing.Sub
{
	[HandleError]
    public class _Controller : Controller
    {
        #region Index

        public ActionResult Index()
		{
            return View();
        }

        #endregion
    }
}