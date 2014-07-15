using Microsoft.Practices.ServiceLocation;
using SolrNetLight.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrNetLight.ConsoleApp
{
    public class CustomerService
    {
        private ISolrOperations<CustomerIndex> _customerSolRInstance;

        public CustomerService()
        {
            _customerSolRInstance = ServiceLocator.Current.GetInstance<ISolrOperations<CustomerIndex>>();
        }

        /// <summary>
        /// Get Customer by firstName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<CustomerIndex> GetCustomerByName(string firstName)
        {
            CustomerIndex result = null;
            try
            {
                var results = await _customerSolRInstance.Query(new SolrQueryByField("firstName", firstName));
                if (results != null && results.Count > 0)
                {
                    result = results[0];
                }

            }
            catch (SolrNetException ex)
            {
                
            }


            return result;
        }

        /// <summary>
        /// Add new customers
        /// </summary>
        public async Task AddCustomers()
        {
            try
            {
                var dlamande = new CustomerIndex
                {
                    Id = 1000,
                    FirstName = "Dorian",
                    LastName = "Lamande",
                    Roles = new List<string> { ".NET" },
                    PhoneNumber = { new KeyValuePair<String, String>("mobile", "0123456789"), new KeyValuePair<String, String>("home", "0123456789") }
                };

                var gfabrizi = new CustomerIndex
                {
                    Id = 1001,
                    FirstName = "Guillaume",
                    LastName = "Fabrizi",
                    Roles = new List<string> { ".NET" },
                    PhoneNumber = { new KeyValuePair<String, String>("mobile", "0123456789"), new KeyValuePair<String, String>("home", "0123456789") }
                };

                await _customerSolRInstance.Add(dlamande);
                await _customerSolRInstance.Add(gfabrizi);
              
                await _customerSolRInstance.Commit();
            }
            catch (Exception ex)
            {
            }
        }

    }
}
