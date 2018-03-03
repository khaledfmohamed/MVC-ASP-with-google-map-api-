using Events.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repository.Interfaces
{
    public interface ICityRepository : IRepository<City , int>
    {

        List<City> GetByCountry(int countryId);

    }
}
