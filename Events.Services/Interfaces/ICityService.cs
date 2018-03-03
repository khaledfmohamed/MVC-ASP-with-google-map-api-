using Events.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Services.Interfaces
{
    public interface ICityService : IService<City> 
    {
         List<City>  GetByCountry(int countryId);
    }



}
