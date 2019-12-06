using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WondermazingGameStore.Domain;

namespace WondermazigGameStore.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
