using OrderTakerProject.Core.Models.DatabaseDTOs;
using OrderTakerProject.Repository.Models.Entity;
using OrderTakerProject.Repository.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Services.Implementation
{
    public class CustomerService : ICustomerService, IDisposable
    {
        private bool _disposed;
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public GetCustomerModel GetCustomerById(int id)
        {
            var response = new GetCustomerModel();
            response = _context.Customers.Where(c => c.Id == id).
                Select(c => new GetCustomerModel
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    MobileNumber =c.MobileNumber,
                    City = c.City,
                    IsActive = c.IsActive,
                    FirstName = c.FirstName,
                    LastName = c.LastName

                }).FirstOrDefault();
                ;
            return response;
        }
        public GetCustomerModel GetCustomerByFullName(string name)
        {
            var response = new GetCustomerModel();
            response = _context.Customers.Where(c => c.FullName.Contains(name)).
                Select(c => new GetCustomerModel
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    MobileNumber = c.MobileNumber,
                    City = c.City,
                    IsActive = c.IsActive,
                    FirstName = c.FirstName,
                    LastName = c.LastName

                }).FirstOrDefault();
            ;
            return response;
        }
        public List<GetCustomerModel> GetCustomers()
        {
            var response = new List<GetCustomerModel>();
            response = _context.Customers.
                Select(c => new GetCustomerModel
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    MobileNumber = c.MobileNumber,
                    City = c.City,
                    IsActive = c.IsActive,
                    FirstName = c.FirstName,
                    LastName = c.LastName
                }).ToList();

            return response;
        }

        public DbResult SaveCustomer(SaveCustomerModel model)
        {
            var response = new DbResult();
            try
            {
                var dbResponse = _context.Customers.Add(new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullName = $"{model.LastName}, {model.FirstName}",
                    MobileNumber = model.MobileNumber,
                    City = model.City
                });
                _context.SaveChanges();
                response.Success = true;
                response.Message = "Success";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }
        public DbResult UpdateCustomer(UpdateCustomerModel model)
        {
            var response = new DbResult();
            try
            {
                var customer = _context.Customers.Where(c => c.Id == model.Id).FirstOrDefault();
                if(customer != null)
                {
                    customer.FirstName = model.FirstName;
                    customer.LastName = model.LastName;
                    customer.FullName = $"{model.LastName}, {model.FirstName}";
                    customer.MobileNumber = model.MobileNumber;
                    customer.City = model.City;
                    customer.IsActive = model.IsActive;
                    _context.SaveChanges();
                }
                response.Success = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        #region
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposed = true;
        }

        
        #endregion

    }
}
