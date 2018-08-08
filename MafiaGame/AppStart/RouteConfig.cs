using System.Web.Mvc;
using System.Web.Routing;

namespace MafiaGame
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: null,
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: null,
                url: "activities/{controller}/{action}",
                namespaces: new[] { "MafiaGame.Controllers.Activities" }
            );
        }
    }
}
