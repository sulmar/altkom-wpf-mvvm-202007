using Altkom.WPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.WPFMVVM.DbServices
{

    // PM> Install-Package EntityFramework
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Models.Action> Actions { get; set; }

        public MyContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
