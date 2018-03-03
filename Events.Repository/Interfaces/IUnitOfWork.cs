using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         IEventRepository Event { get;  }
         ICountryRepository Country { get;  }
         ICityRepository City { get;  }
        void Complete();
    }
}
