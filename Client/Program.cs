using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using Topshelf;
using StructureMap.Configuration.DSL;
using ViewModel;
using Generic_Repository_Test;

namespace GenericRepositoryTest
{
    public class Program
    {
        public static void Main()
        {
            Container container = new Container(new DependencyRegistry());

            #region ConfigureHostFactory
            HostFactory.Run(x =>                                 
            {
                x.Service<DoTheWork>(s =>                        
                {
                    s.ConstructUsing(name => new DoTheWork()); 
                    s.WhenStarted(tc => tc.Start(container.GetInstance<IGenericRepository<Customer>>()));              
                    s.WhenStopped(tc => tc.Stop());               
                });
                x.RunAsLocalSystem();                           

                x.SetDescription("Generic Repository Test");
                x.SetDisplayName("GenericRepositoryTest");
                x.SetServiceName("GenericRepositoryTest");                      
            });
            #endregion                                         
        }
    }

    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            //For<IGenericRepository<Customer>>().Use<GenericRepository<CustomerContext, Customer>>();
            For<ICustomerContext>()
                    .Use<CustomerContext>()
                    .Ctor<string>("connectionString")
                    .EqualToAppSetting("ConnectionString");

                /*
            Scan(x =>
            {
                x.AssembliesFromApplicationBaseDirectory();
                x.WithDefaultConventions();
            });
                */
        }
    }

    public class DoTheWork {
        public void Start(IGenericRepository<Customer> customerRepository)
        { 
            
        }
        public void Stop() { }
    }

}
