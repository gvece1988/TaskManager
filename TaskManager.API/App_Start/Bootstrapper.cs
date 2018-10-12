using TaskManager.BLL;
using TaskManager.DAL;
using Unity;

namespace TaskManager.API.App_Start
{
    public class Bootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {            
            container.RegisterType<ITaskBL, TaskBL>();
            container.RegisterType<ITaskManagerContext, TaskManagerContext>();            
        }
    }
}