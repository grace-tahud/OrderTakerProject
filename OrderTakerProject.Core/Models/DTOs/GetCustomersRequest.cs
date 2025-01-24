using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class GetCustomersRequest
    {
    }
    public class GetCustomersResponse
    {
        public List<CustomerModel> Customers { get; set; }
    }
    public class CustomerModel
    {
        [IgnoreDataMember]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }

        [IgnoreDataMember]
        public string FirstName { get; set; }
        [IgnoreDataMember]
        public string LastName { get; set; }
    }
}
