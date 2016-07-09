using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null, "", new { controller = "Product", action = "List", category = (string)null, page = 1 }
                );//1
            routes.MapRoute(null, "Page{page}",
                new { controller = "Product", action = "List", category = (string)null },
                new { page = @"\d+" }
                );//2
            routes.MapRoute(null, "{category}",
                new { controller = "Product", action = "List", page = 1 }
                );//3
            routes.MapRoute(null, "{category}/Page{page}",
                new { controller = "Product", action = "List" },
                new { page = @"\d+" }
                );//4
            routes.MapRoute(null, "{controller}/{action}");//5
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            //);
        }
    }
}
