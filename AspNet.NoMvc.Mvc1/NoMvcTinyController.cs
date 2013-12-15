using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc1
{
    public abstract class NoMvcTinyController : Controller
	{
        protected override void ExecuteCore()
        {
            TempData.Load(ControllerContext, TempDataProvider);

            var httpMethod = ControllerContext.HttpContext.Request.HttpMethod.ToLower();
            var succeeded = ActionInvoker.InvokeAction(ControllerContext, httpMethod);
            if (!succeeded)
            {
                HandleUnknownAction(httpMethod);
            }

            TempData.Save(ControllerContext, TempDataProvider);
        }
	}
}