using Events.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repository.Interfaces
{
    public interface IEventRepository : IRepository<Event, int>
    {

         List<Event> GetFromIndex(int startIndex, int size);
        
    }
}
