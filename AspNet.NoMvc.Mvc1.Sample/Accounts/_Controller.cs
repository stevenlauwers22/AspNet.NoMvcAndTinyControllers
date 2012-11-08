using System;
using System.Globalization;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc1.Sample.Accounts
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

        #region LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(LogOnModel model)
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

        #endregion

        #region LogOff

        public ActionResult LogOff()
        {
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Register

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = 8;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(string userName, string email, string password, string confirmPassword)
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

        #endregion

        #region ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = 8;
            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChangePassword(ChangePasswordModel model)
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

        #endregion

        #region ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #endregion
    }
}