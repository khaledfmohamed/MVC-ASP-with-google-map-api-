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
    public class CityRepository : RepositoryBase<City, int> , ICityRepository
    {
        public CityRepository(DbContextBase dbContext) : base(dbContext)
        {
        }

        public List<City> GetByCountry(int countryId)
        {
          return  _dbContext.City.Where(c => c.CountryId == countryId).ToList();
        }
    }
}
