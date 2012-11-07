using System;
using System.Globalization;
using System.Web.Mvc;
using AspNet.TinyControllers.Mvc1.Sample.Models.Accounts;

namespace AspNet.TinyControllers.Mvc1.Sample.Controllers.Accounts
{
    [HandleError]
    public class ChangePasswordController : TinyController
	{
        [Authorize]
		public ActionResult Get()
		{
			ViewData["PasswordLength"] = 8;
            return View();
		}

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Post(ChangePasswordModel model)
		{
			ViewData["PasswordLength"] = 8;

            if (!ValidateChangePassword(model))
			{
				return View();
			}

            return RedirectToAction("ChangePasswordSuccess", "Accounts");
		}

        private bool ValidateChangePassword(ChangePasswordModel model)
		{
            if (String.IsNullOrEmpty(model.CurrentPassword))
			{
				ModelState.AddModelError("CurrentPassword", "You must specify a current password.");
			}

            if (model.NewPassword == null || model.NewPassword.Length < 8)
			{
				ModelState.AddModelError("NewPassword", String.Format(CultureInfo.CurrentCulture, "You must specify a new password of {0} or more characters.", 8));
			}

            if (!String.Equals(model.NewPassword, model.ConfirmPassword, StringComparison.Ordinal))
			{
				ModelState.AddModelError("_FORM", "The new password and confirmation password do not match.");
			}

			return ModelState.IsValid;
		}
	}
}