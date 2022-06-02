using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace web_car_demo2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] {"web_car_demo2.Controllers"}
            );
            routes.MapRoute(
                name: "search",
                url: "{search}/{id}",
                defaults: new {controller = "Search", action = "Index"}
            );
            routes.MapRoute(
                name:"Admin",
                url: "admin/homeAdmin/{action}/{id}",
                defaults: new { controller = "homeAdmin", action="Index",id = UrlParameter.Optional}
            );
        }
    }
}
