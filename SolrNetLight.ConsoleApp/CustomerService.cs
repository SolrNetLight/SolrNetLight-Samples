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
        /// Get Customer by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CustomerIndex GetCustomerByName(string name)
        {
            CustomerIndex result = null;
            try
            {
                var results = _customerSolRInstance.Query(new SolrQueryByField("name", name));
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
        public void AddCustomers()
        {
            try
            {
                var dlamande = new CustomerIndex
                {
                    Id = 1104,
                    FirstName = "Dorian",
                    LastName = "Lamande",
                    Roles = ".NET",
                    PhoneNumber = { new KeyValuePair<String, String>("mobile", "0123456789"), new KeyValuePair<String, String>("home", "0123456789") }
                };

                var gfabrizi = new CustomerIndex
                {
                    Id = 1105,
                    FirstName = "Guillaume",
                    LastName = "Fabrizi",
                    Roles = ".NET",
                    PhoneNumber = { new KeyValuePair<String, String>("mobile", "0123456789"), new KeyValuePair<String, String>("home", "0123456789") }
                };

                _customerSolRInstance.Add(dlamande);
                _customerSolRInstance.Add(gfabrizi);
              
                _customerSolRInstance.Commit();
            }
            catch (Exception ex)
            {
            }
        }

    }
}
