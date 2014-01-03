using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace commenergy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             "ArticleItem",
             "{controller}/{yyyy}/{mm}/{dd}/{key}",
            new { controller = "Articles", action = "Display" }
        );

            routes.MapRoute(
            "ArticleItemk",
            "{controller}/{yyyy}/{mm}/{dd}/{key}/display",
           new { controller = "Articles", action = "Displays" }
       );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Articles", action = "Index", id = UrlParameter.Optional }
            );
         
        }
    }
}