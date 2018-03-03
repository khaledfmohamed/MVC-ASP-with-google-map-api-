using Events.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Repository.Interfaces;
using MessageTube;
using Unity.Attributes;
using Unity.Resolution;
using Unity;

namespace Events.Services
{
    public class ServiceContext : IServiceContext
    {
        IEventService _eventService;
        ICountryService _countryService;
        ICityService _cityService;
        [Dependency]
        public IMessageList MessageList { get; set; }
        [Dependency]
        public IUnitOfWork UnitOfWork { get; set; }
        
        public IEventService EventService
        {
            get
            {

                if (_eventService == null)
                {
                    _eventService = UnityConfig.Container.Resolve<IEventService>(new ResolverOverride[]
                          {
                              new ParameterOverride("unitOfWork", UnitOfWork) , new ParameterOverride("message", MessageList)
                          });

                }

                return _eventService;
            }
        }

       

        public ICountryService CountryService
        {
            get
            {

                if (_countryService == null)
                {
                    _countryService = UnityConfig.Container.Resolve<ICountryService>(new ResolverOverride[]
                          {
                              new ParameterOverride("unitOfWork", UnitOfWork) , new ParameterOverride("message", MessageList)
                          });

                }

                return _countryService;
            }
        }
        public ICityService CityService
        {
            get
            {

                if (_cityService == null)
                {
                    _cityService = UnityConfig.Container.Resolve<ICityService>(new ResolverOverride[]
                          {
                              new ParameterOverride("unitOfWork", UnitOfWork) , new ParameterOverride("message", MessageList)
                          });

                }

                return _cityService;
            }
        }

        public void Complete()
        {
            UnitOfWork.Complete();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
