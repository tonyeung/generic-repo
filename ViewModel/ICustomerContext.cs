using Generic_Repository_Test;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public interface ICustomerContext : IUnitOfWork
    {
        DbSet<Customer> Customers { get; set; }
    }
}
