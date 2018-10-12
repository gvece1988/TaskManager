using System.Web.Routing;
using System.Web.Mvc;

namespace TaskManager.API
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Help Area",
                url: string.Empty,
                defaults: new { controller = "Help", action = "Index" }
            ).DataTokens = new RouteValueDictionary(new { area = "HelpPage" });
        }
    }
}