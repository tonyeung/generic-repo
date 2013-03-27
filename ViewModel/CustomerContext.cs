using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CustomerContext : DbContext, ICustomerContext
    {
        public CustomerContext() { }

        public CustomerContext(string connectionString) : base(connectionString) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
