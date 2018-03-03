using Events.Repository;
using Events.Repository.Interfaces;
using Events.Services;
using Events.Services.Interfaces;
using Events.View.Controllers;
using MessageTube;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Events.View
{
    public static class UnityConfig
    {
        public static UnityContainer Container { get; set; }
        public static void RegisterComponents()
        {
            Container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
            Container.RegisterType<AccountController>(new InjectionConstructor());

            Container.RegisterType<ManageController>(new InjectionConstructor());
            Container.RegisterType<IMessageList, MessageList>();
            Container.RegisterType<IServiceContext, ServiceContext>();
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Services.UnityConfig.RegisterComponents();
        }
    }
}