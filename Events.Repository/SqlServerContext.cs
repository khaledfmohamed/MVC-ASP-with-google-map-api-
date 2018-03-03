using Events.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repository
{
    public class SqlServerContext : DbContextBase
    {
        public SqlServerContext()
            : base("name=SqlServerModel")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SqlServerContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
