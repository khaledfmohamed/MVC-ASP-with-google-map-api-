using Events.Repository.Interfaces;
using MessageTube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Services.Interfaces
{
    public interface IServiceContext : IDisposable
    {

        IMessageList MessageList { get; }
        IUnitOfWork UnitOfWork { get; }
        IEventService EventService { get; }
        ICountryService CountryService { get; }
        ICityService CityService { get; }
        void Complete();

    }
}
