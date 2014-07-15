using System;
using System.Threading.Tasks;

namespace SolrNetLight.ConsoleApp
{
    class Program
    {
        private static CustomerService _customerService;

        static void Main(string[] args)
        {
            //Initialize Solr Customer Index with current Solr local instance
            Startup.Init<CustomerIndex>(String.Format("{0}{1}", "http://localhost:8983/solr/", CustomerIndex.INDEX_NAME));

            //Instanciate customer service
            _customerService = new CustomerService();


            DoRequest().Wait();

            Console.ReadLine();
        }

        private static async Task DoRequest()
        {
            //Add query
            await _customerService.AddCustomers();

            //Make simple queries
            CustomerIndex dlamande = await _customerService.GetCustomerByName("Dorian");
            CustomerIndex gfabrizi = await _customerService.GetCustomerByName("Guillaume");

            //Display results
            Console.WriteLine(String.Concat(dlamande.FirstName, dlamande.LastName));
            Console.WriteLine(String.Concat(gfabrizi.FirstName, gfabrizi.LastName));


        }
    }
}
