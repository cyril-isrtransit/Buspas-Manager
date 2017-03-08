using BuspasManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace BuspasManager.ActionFilter
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ConfigAuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {         
            RoleModel roleModel = ((LogOnModel)httpContext.Session["LogOnModel"])?.Roles;

            if ((roleModel == null) || (!roleModel.CanViewConfiguration))
                return false;

            return base.AuthorizeCore(httpContext);
        }
    }

    public class RealtimeMessageAuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            RoleModel roleModel = ((LogOnModel)httpContext.Session["LogOnModel"])?.Roles;

            if ((roleModel == null) || (!roleModel.CanViewRealTimeMessages))
                return false;

            return base.AuthorizeCore(httpContext);
        }
    }
}
