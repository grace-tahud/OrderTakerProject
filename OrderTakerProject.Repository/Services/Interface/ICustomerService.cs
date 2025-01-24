﻿using OrderTakerProject.Core.Models.DatabaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Services.Interface
{
    public interface ICustomerService
    {
        public DbResult SaveCustomer(SaveCustomerModel model);
        public DbResult UpdateCustomer(UpdateCustomerModel model);
        public GetCustomerModel GetCustomerById(int id);
        public GetCustomerModel GetCustomerByFullName(string name);
        public List<GetCustomerModel> GetCustomers();
    }
}
