using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class GetCustomerRequest
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }

    public class GetCustomerResponse:BaseResponse
    {
        public CustomerModel Customer { get; set; }
    }
}
