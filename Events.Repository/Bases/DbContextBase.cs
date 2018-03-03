using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Events.Model;

namespace Events.Repository.Bases
{
    public abstract class DbContextBase : System.Data.Entity.DbContext
    {
        public DbContextBase(string Name)
            : base(Name)
        {

        }


        public DbSet<Event> Event {get; set;}
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }

    }

}
