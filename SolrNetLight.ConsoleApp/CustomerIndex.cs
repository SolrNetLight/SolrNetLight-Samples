using Newtonsoft.Json;
using SolrNetLight.Attributes;
using SolrNetLight.Impl.FieldSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SolrNetLight.ConsoleApp
{
    [DataContract]
    public class CustomerIndex
    {
        public const string INDEX_NAME = "customer";

        [SolrUniqueKey("id")]
        [DataMember(Name="id")]
        public long Id { get; set; }

        [DataMember(Name="lastName")]
        public string LastName { get; set; }

        [DataMember(Name="firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "roles")]
        public string Roles { get; set; }

        [DataMember(Name = "phone_")]
        [JsonConverter(typeof(DictionaryFieldJsonConverter))]
        public IDictionary<String,String> PhoneNumber { get; set; }

        public CustomerIndex()
        {
            PhoneNumber = new Dictionary<String, String>();
        }
    }
}
