using Events.Model;
using Events.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repository.Interfaces
{
    public interface ICountryRepository : IRepository<Country , int>
    {
    }
}
