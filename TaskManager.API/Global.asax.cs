using System.Data.Entity;
using System.Web.Http;
using System.Web.Routing;
using TaskManager.API.App_Start;
using TaskManager.DAL;
using Unity;

namespace TaskManager.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TaskManagerContext>());
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new UnityContainer();
            Bootstrapper.RegisterTypes(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}
