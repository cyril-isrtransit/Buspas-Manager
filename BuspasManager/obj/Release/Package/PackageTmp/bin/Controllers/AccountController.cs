using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SivMsgWebClient.Models;
using SivMsgWebClient.ActionFilter;
using SivMsgWebClient.App_GlobalResources;
using System.Security.Authentication;
using System.Diagnostics;
using System.IO;

namespace SivMsgWebClient.Controllers.Controllers
{

    [HandleError]
    [SetCulture]
    public class AccountController : Controller
    {
        //private UserAspnets db = new UserAspnets();
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }
        public UserAspnets userAspnets = new UserAspnets();

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }
            base.Initialize(requestContext);
        }


        // **************************************
        // URL: /Account/LogOn
        // **************************************
        public ActionResult LogOn()
        {
            try
            {
                if ((Session.Contents["LogOnModel"] != null) && ((LogOnModel)Session.Contents["LogOnModel"]).IsrCom)
                {

                    return View("../IsrCom/LogOn", (LogOnModel)Session.Contents["LogOnModel"]);
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [SetCulture]
        public string LogOn(LogOnModel model, string returnUrl)
        {
            try
            {
                if ((Session.Contents["LogOnModel"] != null) && ((LogOnModel)Session.Contents["LogOnModel"]).IsrCom)
                    model = (LogOnModel)Session.Contents["LogOnModel"];
                else
                {
                    model.Roles = new RoleModel();
                    Session.Contents["LogOnModel"] = model;
                }

                if ((model.IsrCom) || (ModelState.IsValid))
                {
                    if ((model.IsrCom) || (MembershipService.ValidateUser(model.UserName, model.Password)))
                    {
                        FormsService.SignIn(model.UserName, model.RememberMe);
                        if (!String.IsNullOrEmpty(model.ReturnUrl))
                        {
                            Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            //Envois des informations dans le fichier de log
                            //LogsController LogFile = new LogsController();
                            //LogFile.add(3, model.UserName, 4, model.UserName, model.UserName);

                            //Redirection vers la vue Home
                            //RedirectToAction("Index", "Home");
                            return "/Home/Index";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", Resources.LanguageResource.LoginError);
                    }
                }

                // If we got this far, something failed, redisplay form
                return "false";
            }
            catch
            {
                return "false";
            }
        }

        /*public ActionResult Debug()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                var model = new IsrComLogOnModel() { username = "ISRTransit", lang = "fr", organization = App_Settings.ApplicationSettings.Organization, sessionID = "pass4isr", userLevel = "3", roles = new RoleModel("Scheduler") }; 
               // Session.Contents["IsrComLogOnModel"] = model; 
                Session.Contents.Add("LogOnModel", new LogOnModel() { UserName = "ISRTransit", IsrCom = true, ReturnUrl = "/Home/Index", Roles = model.roles });
                LogOn(new LogOnModel() { UserName = "ISRTransit", IsrCom = true, ReturnUrl = "/Home/Index" }, "/Home/Index" );
                return RedirectToAction("/Home/Index");
            }
            else
                return View("Error", new System.Web.Mvc.HandleErrorInfo(new AuthenticationException("Authentification Failed"), "AccountController", "LogOn"));
        }*/

        // **************************************
        // URL: /Account/LogOff
        // **************************************
        public ActionResult LogOff()
        {
            try
            {
                //Envois des informations dans le fichier de log
                //LogsController LogFile = new LogsController();
                //LogFile.add(3, User.Identity.Name, 5, User.Identity.Name, User.Identity.Name);
                FormsService.SignOut();

                return RedirectToAction("LogOn", "Account");
            }
            catch
            {
                return RedirectToAction("LogOn", "Account");
            }
        }


        [Authorize(Roles = "ISR")]
        public ViewResult ManageLogins(int PageIndex = 0)
        {
            try
            {
                ViewBag.PageIndex = PageIndex;
                ViewBag.Role = new SelectList(Roles.GetAllRoles());
                //HttpCookie cult = Request.Cookies["culture"];
                //if (cult == null) ViewData["lang"] = "en"; else ViewData["lang"] = cult.Value;

                return View(userAspnets);
            }
            catch
            {
                return View(userAspnets);
            }
        }


        // **************************************
        // URL: /Account/Register
        // **************************************


        [HttpPost]
        public Boolean Register(RegisterModel model)
        {
            try
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email, model.Role);

                if (createStatus == MembershipCreateStatus.Success)
                {

                    //Envois des informations dans le fichier de log
                    //LogsController LogFile = new LogsController();
                    //LogFile.add(3, model.UserName, 1, User.Identity.Name, model.UserName);
                    //FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return true;
                }
                else
                {
                    //ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                    return false;
                }
            }
            catch
            {
                //ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                return false;
            }
        }


        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(string user)
        {
            //Envois des informations dans le fichier de log
            //LogsController LogFile = new LogsController();
            //LogFile.add(3, user, 2, User.Identity.Name, User.Identity.Name);
            return PartialView(new UserAspnets().First(u => u.MembershipUser.UserName == user));
        }


        [HttpGet, Authorize(Roles = "Admin"), ActionName("DeleteUser")]
        public Boolean DeleteUserConfirmed(string user)
        {
            try
            {
                MembershipService.DeleteUser(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string user)
        {
            return PartialView(new UserAspnets().First(u => u.MembershipUser.UserName == user));
        }


        [HttpPost, ActionName("Edit")]
        public Boolean Edit(string membershipuserusername, string membershipuseremail, string role, bool UnLock = false, string password = "")
        {
            try
            {
                MembershipService.UpdateUser(membershipuserusername, membershipuseremail, role);

                //Envois des informations dans le fichier de log
                //LogsController LogFile = new LogsController();
                //LogFile.add(3, membershipuserusername, 3, User.Identity.Name, "");

                if (UnLock)
                    MembershipService.UnLockUser(membershipuserusername);

                if (password != "")
                {
                    //Changement du mot de passe via un reset
                    ChangeOtherPassword(membershipuserusername, password);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Fonction dedition du profil personnel
        [HttpPost]
        public Boolean EditPersonal(string membershipuserusername, string membershipuseremail, string role)
        {
            try
            {
                if (MembershipService.UpdateUser(membershipuserusername, membershipuseremail, role))
                {
                    //Envois des informations dans le fichier de log
                    //LogsController LogFile = new LogsController();
                    //LogFile.add(3, User.Identity.Name, 3, User.Identity.Name, User.Identity.Name); return true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        //[HttpPost]
        public ActionResult ResetPassword(string username, string email)
        {
            //Envois des informations dans le fichier de log
            genLogFile("Reset du mot de passe de " + username, User.Identity.Name);
            string newPass = MembershipService.ResetPassword(username);

            if (newPass != null && newPass.Length != 0)
            {
                return PartialView("_DialogChangePasswordSuccess", newPass.ToString());
            }

            return PartialView("Error", new HandleErrorInfo(new Exception(Resources.LanguageResource.ErrorCannotResetPassword), this.ToString(), Resources.LanguageResource.ResetPassword));
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                    {
                        ViewBag.ChangePasswordSucceed = true;
                    }
                    else
                    {
                        ModelState.AddModelError("", Resources.LanguageResource.PasswordChangeError);
                    }
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        //Fonction permettant de modifier son propre mot de passe
        [HttpPost]
        public Boolean ChangePersonalPassword(string CurrentPassword, string NewPassword, string ConfirmPassword)
        {
            try
            {
                if (MembershipService.ChangePassword(User.Identity.Name, CurrentPassword, NewPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        //Fonction permettant de changer le password des autres utilisateur
        [Authorize]
        [HttpPost]
        public Boolean ChangeOtherPassword(string Username, string NewPassword)
        {
            try
            {
                //Generation du nouveau password
                var NewPasswordGenerate = MembershipService.ResetPassword(Username);

                //On remplace le password genere par le nouveau
                if (MembershipService.ChangePassword(Username, NewPasswordGenerate, NewPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }


        //Fonction permettant de logger toutes les interaction avec la base de données
        public void genLogFile(string logMessage, string username)
        {
            //Un fichier de log par jour
            string lfp = @"C:\Users\Public\" + DateTime.Now.Date.ToString("yyyyMMdd") + ".log";
            try
            {
                using (StreamWriter w = System.IO.File.AppendText(lfp))
                {
                    w.WriteLine("{0} {1}: {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), username + " : " + logMessage);
                    w.Flush();
                }
            }
            catch
            {

            }
        }

    }
}

