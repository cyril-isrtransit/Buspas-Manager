using BuspasManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft;
using Newtonsoft.Json;

namespace BuspasManager.Controllers
{
    public class IsrComController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }

        public ActionResult Index()
        {
            ViewBag.RedirectView = "/Dashboard/Index";

            return View();
        }

        public ActionResult IndexRealtime()
        {
            ViewBag.RedirectView = "/Realtime/Index";

            return View("Index");
        }

        [HttpPost]
        public void LogOn(String initResult, String returnUrl = "/Home/Index")
        {
            try
            {
                //App_Log.LogClass.SaveToLog(initResult);
                IsrComLogOnModel model = (IsrComLogOnModel)Newtonsoft.Json.JsonConvert.DeserializeObject(initResult, typeof(IsrComLogOnModel));

                //temporary until new ISrcom including rolename
               // model.roles = new RoleModel(StringCipher.Decrypt(model.b, model.sessionID));
                model.roles = new RoleModel();

                Session.Contents.Add("LogOnModel", new LogOnModel() { UserName = model.username, IsrCom = true, ReturnUrl = returnUrl, Roles = model.roles });

                SetCulture(model.lang);
                //App_Log.LogClass.SaveToLog(model.lang);

                Session.Contents.Add("IsrComLogOnModel", model);

            }
            catch (Exception E)
            {
                //App_Log.LogClass.SaveExceptionToLog(E);
            }
        }

        public void SetCulture(string id)
        {
            HttpCookie userCookie = Request.Cookies["Culture"];
            userCookie.Value = id;
            userCookie.Expires = DateTime.Now.AddYears(100);

            Response.SetCookie(userCookie);
        }
    }
}
