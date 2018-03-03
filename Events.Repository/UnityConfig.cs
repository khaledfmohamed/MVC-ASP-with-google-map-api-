

using Unity;
using Events.Repository.Interfaces;
using Events.Repository;
using Events.Repository.Bases;

namespace Events.Repository
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

            Container.RegisterType<IEventRepository, EventRepository>();
            Container.RegisterType<ICountryRepository, CountryRepository>();
            Container.RegisterType<ICityRepository, CityRepository>();
            Container.RegisterType<DbContextBase, SqlServerContext>();
           
        }
    }
}