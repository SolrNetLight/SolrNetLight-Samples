using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrNetLight.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.Init<CustomerIndex>(String.Format("{0}{1}", "http://localhost:8983/solr/", CustomerIndex.INDEX_NAME));

            CustomerService customer = new CustomerService();
            customer.AddCustomers();

            Console.ReadLine();
        }
    }
}
