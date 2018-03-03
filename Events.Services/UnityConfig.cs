
using Unity;
using Events.Repository.Interfaces;
using Events.Services.Interfaces;
using Events.Repository.Bases;
using Events.Repository;
using MessageTube;

namespace Events.Services
{
    public static class UnityConfig
    {
        
        public static UnityContainer Container { get; set ; }


        public static void RegisterComponents()
        {
			 Container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Container.RegisterType<IMessageList, MessageList>();
            Container.RegisterType<IEventService, EventService>();
            Container.RegisterType<ICountryService, CountryService>();
            Container.RegisterType<ICityService, CityService>();
            Container.RegisterType<ICityRepository, CityRepository>();
            Repository.UnityConfig.RegisterComponents();


        }
    }
}