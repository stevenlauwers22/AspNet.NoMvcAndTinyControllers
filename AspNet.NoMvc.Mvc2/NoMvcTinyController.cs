using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc2
{
    public abstract class NoMvcTinyController : Controller
	{
        protected override void ExecuteCore()
        {
            if (!ControllerContext.IsChildAction)
            {
                TempData.Load(ControllerContext, TempDataProvider);
            }

            var httpMethodOverride = ControllerContext.HttpContext.Request.GetHttpMethodOverride().ToLower();
            var succeeded = ActionInvoker.InvokeAction(ControllerContext, httpMethodOverride);
            if (!succeeded)
            {
                HandleUnknownAction(httpMethodOverride);
            }

            if (!ControllerContext.IsChildAction)
            {
                TempData.Save(ControllerContext, TempDataProvider);
            }
        }
	}
}