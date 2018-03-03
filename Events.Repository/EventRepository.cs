using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Repository.Bases;
using Events.Model;
using Events.Repository.Interfaces;

namespace Events.Repository
{
    public class EventRepository : RepositoryBase<Event, int> , IEventRepository
    {
        public EventRepository(DbContextBase dbContext) : base(dbContext)
        {
        }

        public List<Event> GetFromIndex(int startIndex, int size)
        {
           
             return _dbContext.Event.OrderBy(e => e.StartDate).OrderBy(e => e.Id).Skip(startIndex).Take(size).ToList();
           
        }
    }
}
