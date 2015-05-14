using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectXXX
{
    public static class RouteCollectionExtensions
    {
        public static Route MapRouteWithName(this RouteCollection routes,
        string name, string url, object defaults, object constraints)
        {
            Route route = routes.MapRoute(name, url, defaults, constraints);
            route.DataTokens = new RouteValueDictionary();
            route.DataTokens.Add("RouteName", name);

            return route;
        }
    }

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRouteWithName(
                name: "EventList",
                url: "eventlist",
                defaults: new { controller = "Events", action = "EventList" },
                constraints: null
                );

            routes.MapRouteWithName(
                name: "Description",
                url: "description/{id}",
                defaults: new { controller = "Events", action = "Description", id = 0 },
                constraints: null
                );

            routes.MapRouteWithName(
                name: "Create",
                url: "Events/Create",
                defaults: new { controller = "Events", action = "Create"},
                constraints: null
                );

            routes.MapRouteWithName(
              name: "EventNotFound",
              url: "Description/{id}",
              defaults: new { controller = "Error", action = "EventNotFound" },
              constraints: null
              );

            routes.MapRouteWithName(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index"},
                constraints: null
                );          

            routes.MapRouteWithName(
                name: "404-PageNotFound",
                url: "{*url}",
                defaults: new { controller = "Error", action = "PageNotFound", id = UrlParameter.Optional },
                constraints: null
            );

            
         
        }
    }
}