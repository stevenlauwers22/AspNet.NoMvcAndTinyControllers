using System;
using System.Globalization;
using System.Web.Mvc;
using AspNet.NoMvc.Mvc2;

namespace AspNet.NoMvcAndTinyControllers.Sample.Accounts
{
    [HandleError]
    public class RegisterController : NoMvcTinyController
    {
		public ActionResult Get()
		{
			ViewData["PasswordLength"] = 8;
            return View();
		}

        [HttpPost]
		public ActionResult Post(string userName, string email, string password, string confirmPassword)
		{
            if (ValidateRegistration(userName, email, password, confirmPassword))
			{
			    return RedirectToAction("Index", "Home");
			}

            ViewData["PasswordLength"] = 8;
			return View();
		}

		private bool ValidateRegistration(string userName, string email, string password, string confirmPassword)
		{
			if (String.IsNullOrEmpty(userName))
			{
				ModelState.AddModelError("username", "You must specify a username.");
			}

			if (String.IsNullOrEmpty(email))
			{
				ModelState.AddModelError("email", "You must specify an email address.");
			}

			if (password == null || password.Length < 8)
			{
				ModelState.AddModelError("password", String.Format(CultureInfo.CurrentCulture, "You must specify a password of {0} or more characters.", 8));
			}

			if (!String.Equals(password, confirmPassword, StringComparison.Ordinal))
			{
				ModelState.AddModelError("_FORM", "The new password and confirmation password do not match.");
			}

			return ModelState.IsValid;
		}
	}
}