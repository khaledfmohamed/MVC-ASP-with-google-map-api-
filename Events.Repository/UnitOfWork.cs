
using Events.Repository.Bases;
using Events.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;

namespace Events.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        IEventRepository _event;
        ICountryRepository _country;
        ICityRepository _city;
        DbContextBase _dbContextBase;
        public IEventRepository Event
        {
            get
            {
                if (_event == null)
                    _event = UnityConfig.Container.Resolve<IEventRepository>(new ResolverOverride[]
                          {
                              new ParameterOverride("dbContext", DbContext)
                          });
                return _event;

            }
        }
        public ICountryRepository Country
        {
            get
            {
                if (_country == null)
                    _country = UnityConfig.Container.Resolve<ICountryRepository>(new ResolverOverride[]
                          {
                              new ParameterOverride("dbContext", DbContext)
                          });
                return _country;

            }
        }
        public ICityRepository City {
            get
            {
                if (_city == null)
                    _city = UnityConfig.Container.Resolve<ICityRepository>(new ResolverOverride[]
                          {
                              new ParameterOverride("dbContext", DbContext) 
                          });
                return _city;

            }
        }

        public DbContextBase DbContext {
            get
            {
                if (_dbContextBase == null)
                    _dbContextBase = UnityConfig.Container.Resolve<DbContextBase>();
                return _dbContextBase;

            }
        }

        
        public void Complete()
        {
            DbContext.SaveChanges();
        }
        public void CompleteAsc()
        {
            DbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
           
            DbContext.Dispose();
        }
    }
}
