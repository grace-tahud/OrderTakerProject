using OrderTakerProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.UI.Models
{
    public class CustomerViewModel
    {
        public List<CustomerModel> Customers { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
