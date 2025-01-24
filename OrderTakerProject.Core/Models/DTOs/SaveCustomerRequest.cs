using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class SaveCustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
    }
    public class SaveCustomerResponse
    {
        public string Message { get; set; }
    }
}
