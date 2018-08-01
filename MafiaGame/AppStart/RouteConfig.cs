using System.Web.Mvc;
using System.Web.Routing;

namespace MafiaGame
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Store",
                url: "activities/store/{action}",
                defaults: new { controller = "Store", id = UrlParameter.Optional }
            );

            routes.IgnoreRoute("{controller}/{action}/Index");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
