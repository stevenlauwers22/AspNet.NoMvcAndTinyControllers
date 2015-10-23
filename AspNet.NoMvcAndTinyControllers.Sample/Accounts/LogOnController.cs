using System;
using System.Web.Mvc;
using AspNet.NoMvc.Mvc2;

namespace AspNet.NoMvcAndTinyControllers.Sample.Accounts
{
    [HandleError]
    public class LogOnController : NoMvcTinyController
    {
		public ActionResult Get()
		{
            return View();
		}

		[HttpPost]
		public ActionResult Post(LogOnModel model)
		{
            if (!ValidateLogOn(model))
			{
				return View();
			}

			if (!String.IsNullOrEmpty(model.ReturnUrl))
			{
				return Redirect(model.ReturnUrl);
			}
		    
            return RedirectToAction("Index", "Home");
		}

        private bool ValidateLogOn(LogOnModel model)
        {
            if (String.IsNullOrEmpty(model.Username))
            {
                ModelState.AddModelError("Username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "You must specify a password.");
            }

            return ModelState.IsValid;
        }
	}
}