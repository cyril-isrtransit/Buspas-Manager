using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BuspasManager
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public enum Culture
    {
        en = 1,
        fr = 2
    }

    public class Int64ModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value != null)
            {
                Int64 intValue;
                if (Int64.TryParse(value.AttemptedValue.ToString(), out intValue))
                {
                    return intValue;
                }
                else
                {
                    bindingContext.ModelState.AddModelError(
                        bindingContext.ModelName,
                        string.Format("{0} is an invalid date format", value.AttemptedValue)
                    );
                }
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
    public class TimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            // Ensure there's incomming data
            var key = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider
                .GetValue(key);

            if (valueProviderResult == null ||
                string.IsNullOrEmpty(valueProviderResult
                    .AttemptedValue))
            {
                return null;
            }

            // Preserve it in case we need to redisplay the form
            bindingContext.ModelState
                .SetModelValue(key, valueProviderResult);

            String hours, minutes;
            if (((string[])valueProviderResult.RawValue).Count() == 1)
            {
                string[] values = ((string[])valueProviderResult.RawValue)[0].Split(':');
                 hours = values[0];
                 minutes = values[1];
            }
            else
            {
                // Parse
                hours = ((string[])valueProviderResult.RawValue)[0];
                minutes = ((string[])valueProviderResult.RawValue)[1];
            }

            // A TimeSpan represents the time elapsed since midnight
            var time = new TimeSpan(Convert.ToInt32(hours),
                Convert.ToInt32(minutes), 0);

            return time;
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new AuthorizeAttribute());
            filters.Add(new HandleErrorAttribute()); 
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Account", action = "LogOn", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(TimeSpan), new TimeBinder());
            //ModelBinders.Binders.Add(typeof(Int16), new Int64ModelBinder());
            ////ModelBinders.Binders.Add(typeof(int), new Int16ModelBinder());
            //ModelBinders.Binders.Add(typeof(Int32), new Int64ModelBinder());
            //ModelBinders.Binders.Add(typeof(Int64), new Int64ModelBinder());
        }

        
    }
}