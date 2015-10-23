using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc5
{
    public abstract class NoMvcTinyController : Controller
	{
        protected override bool DisableAsyncSupport
        {
            // Disable async support for now
            // Overriding the BeginExecuteCore causes too much problems because it uses quite some internal methods/classes
            get { return true; }
        }

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