using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplicationWebAPI1.Areas.MyArea
{
    public class MyAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MyArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MyArea_default",
                "MyArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            // solution from 
            // http://blogs.infosupport.com/asp-net-mvc-4-rc-getting-webapi-and-areas-to-play-nicely/
            context.MapHttpRoute(
                "MyArea_api",
                "api/MyArea/{controller}/{action}/{id}",
                new { id = System.Web.Http.RouteParameter.Optional }
                );
        }
    }

    public static class AreaRegistrationContextExtensions
    {
        public static Route MapHttpRoute(this AreaRegistrationContext context, string name, string routeTemplate)
        {
            return context.MapHttpRoute(name, routeTemplate, null, null);
        }

        public static Route MapHttpRoute(this AreaRegistrationContext context, string name, string routeTemplate, object defaults)
        {
            return context.MapHttpRoute(name, routeTemplate, defaults, null);
        }

        public static Route MapHttpRoute(this AreaRegistrationContext context, string name, string routeTemplate, object defaults, object constraints)
        {
            var route = context.Routes.MapHttpRoute(name, routeTemplate, defaults, constraints);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("area", context.AreaName);
            return route;
        }
    }
}