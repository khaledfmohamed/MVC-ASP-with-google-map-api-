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
   public class CountryRepository : RepositoryBase<Country, int> , ICountryRepository
    {
        public CountryRepository(DbContextBase dbContext) : base(dbContext)
        {
        }
    }
}
