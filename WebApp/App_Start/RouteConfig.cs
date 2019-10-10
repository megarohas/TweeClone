using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
              name: "Pic",
              url: "Images/Index/{Pic}",
              defaults: new { controller = "Images", action = "Index" }
         );

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Sub",
               url: "Home/SubAdd/{n}",
               defaults: new { controller = "Home", action = "SubAdd" }
          );



            routes.MapRoute(
                "Profile",
                "{controller}/{action}/{name}",
                new { controller = "Home", action = "PersTweet"}
            );

           

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
