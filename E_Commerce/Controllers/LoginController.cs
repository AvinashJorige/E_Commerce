using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;
using CoreModel.Mappings;
using System.Security.Principal;
using System.Web.Security;
using Service.Implementations;
using Service.Interfaces;

namespace E_Commerce.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        //GET: EnsureLoggedOut
        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }

        [HttpGet]
        public ActionResult loginAccess()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();
            return View();
        }

        /// <summary>
        /// reference link : https://www.getdonedone.com/building-the-optimal-user-database-model-for-your-application/
        /// reference link : http://www.databasezone.com/samples/User/
        /// 
        /// </summary>
        /// <param name="_log"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult loginAccess(ecom_tbl_User _log)
        {
            string OldHASHValue = string.Empty;
            IGenericService<ecom_tbl_User> _igenericService = new GenericService<ecom_tbl_User>();

            ecom_tbl_User _logInfo = new ecom_tbl_User();

            if (ModelState.IsValid)
            {
                if (_log != null && _log.Password != null && _log.UserName != null)
                {
                    _logInfo = _igenericService.GetFirstOrDefault(filter: q => q.UserName == _log.UserName && q.Password == _log.Password);
                    if (_logInfo != null)
                    {
                        if (_logInfo.PasswordHashKey != null)
                        {
                            OldHASHValue = _logInfo.PasswordHashKey == null ? new Cipher().Encrypt(_log.UserName + _log.Password) : _logInfo.PasswordHashKey;
                            bool isLogin = CompareHashValue(_log.UserName.ToString(), _log.Password, OldHASHValue);


                            if (isLogin)
                            {
                                //Login Success
                                //For Set Authentication in Cookie (Remeber ME Option)
                                SignInRemember(_logInfo.UserName.ToString(), false);

                                Session["User_Email"] = _logInfo.Email;
                                Session["User_Name"] = _logInfo.UserName;
                                Session["UserID"] = _logInfo.UserId;

                                //Set A Unique ID in session
                                if (_logInfo.UserRole == "Admin")
                                {
                                    return RedirectToAction("Index", "Admin/Admin_Category");
                                }
                                else
                                {
                                    return RedirectToAction("Index", "Customer/Home");
                                }
                            }
                        }
                    }
                }

            }
            return RedirectToAction("loginAccess");
        }
        public bool CompareHashValue(string pharse1, string pharse2, string OldHASHValue)
        {
            try
            {
                string expectedHashString = new Cipher().Encrypt((pharse1 + pharse2));

                return (OldHASHValue == expectedHashString);
            }
            catch
            {
                return false;
            }
        }

        //GET: SignInAsync
        private void SignInRemember(string userName, bool isPersistent = false)
        {
            try
            {
                // Clear any lingering authencation data
                FormsAuthentication.SignOut();

                // Write the authentication cookie
                FormsAuthentication.SetAuthCookie(userName, isPersistent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET: RedirectToLocal
        private ActionResult RedirectToLocal(string returnURL = "")
        {
            try
            {
                // If the return url starts with a slash "/" we assume it belongs to our site
                // so we will redirect to this "action"
                if (!string.IsNullOrWhiteSpace(returnURL) && Url.IsLocalUrl(returnURL))
                    return Redirect(returnURL);

                // If we cannot verify if the url is local to our host we redirect to a default location
                return RedirectToAction("loginAccess", "loginAccess");
            }
            catch
            {
                throw;
            }
        }


        //POST: Logout
        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                // First we clean the authentication ticket like always
                //required NameSpace: using System.Web.Security;
                FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication
                //required NameSpace: using System.Security.Principal;
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();

                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
                // this clears the Request.IsAuthenticated flag since this triggers a new request
                return RedirectToLocal();
            }
            catch
            {
                throw;
            }
        }



    }
}