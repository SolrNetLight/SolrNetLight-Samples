using System;

namespace SolrNetLight.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize Solr Customer Index with current Solr local instance
            Startup.Init<CustomerIndex>(String.Format("{0}{1}", "http://localhost:8983/solr/", CustomerIndex.INDEX_NAME));

            //Instanciate customer service
            CustomerService customer = new CustomerService();

            //Make simple queries
            CustomerIndex dlamande = customer.GetCustomerByName("Dorian");
            CustomerIndex gfabrizi = customer.GetCustomerByName("Guillaume");

            //Display results
            Console.WriteLine(String.Concat(dlamande.FirstName, dlamande.LastName));
            Console.WriteLine(String.Concat(gfabrizi.FirstName, gfabrizi.LastName));

            //customer.AddCustomers();

            Console.ReadLine();
        }
    }
}
