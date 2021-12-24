using NewsWebApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebApp.DAL.EF
{
    public class DataContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Heading> Headings { get; set; }

        static DataContext()
        {
            Database.SetInitializer<DataContext>(new StoreDbInitializer());
        }

        public DataContext(string connectionString) : base(connectionString)
        {

        }

       
    }
}
