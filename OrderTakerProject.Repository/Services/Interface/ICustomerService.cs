using OrderTakerProject.Core.Models.DatabaseDTOs;
using OrderTakerProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Services.Interface
{
    public interface ICustomerService
    {
        public SaveCustomerResponse SaveCustomer(SaveCustomerModel model);
        public UpdateCustomerResponse UpdateCustomer(UpdateCustomerModel model);
        public GetCustomerResponse GetCustomerById(int id);
        public GetCustomerResponse GetCustomerByFullName(string name);
        public GetCustomersResponse GetCustomers();
    }
}
