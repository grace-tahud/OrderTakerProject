using AutoMapper;
using OrderTakerProject.Core.Enumerations;
using OrderTakerProject.Core.Models.DatabaseDTOs;
using OrderTakerProject.Core.Models.DTOs;
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
        private readonly IMapper _mapper;
        public CustomerService(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetCustomerResponse GetCustomerById(int id)
        {
            var response = new GetCustomerResponse();
            try
            {
                var dbResponse = _context.Customers.Where(c => c.Id == id).FirstOrDefault();
                if (dbResponse != null)
                {
                    var customerModel = _mapper.Map<CustomerModel>(dbResponse);
                    response.Customer = customerModel;
                    response.Success = true;
                    response.Result = new Result(BaseResponseCodes.Success);
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
           
            

                //Select(c => new GetCustomerModel
                //{
                //    Id = c.Id,
                //    FullName = c.FullName,
                //    MobileNumber =c.MobileNumber,
                //    City = c.City,
                //    IsActive = c.IsActive,
                //    FirstName = c.FirstName,
                //    LastName = c.LastName

                //}).FirstOrDefault();
                ;
            return response;
        }
        public GetCustomerResponse GetCustomerByFullName(string name)
        {
            var response = new GetCustomerResponse();
            try
            {
                var dbResponse = _context.Customers.Where(c => c.FullName.Contains(name)).FirstOrDefault();
                if (dbResponse != null)
                {
                    var customerModel = _mapper.Map<CustomerModel>(dbResponse);
                    response.Customer = customerModel;
                    response.Success = true;
                    response.Result = new Result(BaseResponseCodes.Success);
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
            //response = _context.Customers.Where(c => c.FullName.Contains(name)).
            //    Select(c => new GetCustomerModel
            //    {
            //        Id = c.Id,
            //        FullName = c.FullName,
            //        MobileNumber = c.MobileNumber,
            //        City = c.City,
            //        IsActive = c.IsActive,
            //        FirstName = c.FirstName,
            //        LastName = c.LastName

            //    }).FirstOrDefault();
            //;
            return response;
        }
        public GetCustomersResponse GetCustomers()
        {
            var response = new GetCustomersResponse();
            try
            {
                var dbResponse = _context.Customers.ToList();
                if(dbResponse != null)
                {
                     var customersModel = _mapper.Map<List<CustomerModel>>(dbResponse);
                    response.Customers = customersModel;
                    response.Success = true;
                    if (dbResponse.Any())
                    {
                        response.Result = new Result(BaseResponseCodes.Success);
                    }
                    else
                    {
                        response.Result = new Result(BaseResponseCodes.NoItems);
                    }
                }
                               //Select(c => new GetCustomerModel
                               //{
                               //    Id = c.Id,
                               //    FullName = c.FullName,
                               //    MobileNumber = c.MobileNumber,
                               //    City = c.City,
                               //    IsActive = c.IsActive,
                               //    FirstName = c.FirstName,
                               //    LastName = c.LastName
                               //}).ToList();
                //response.ba
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
           
           

            return response;
        }

        public SaveCustomerResponse SaveCustomer(SaveCustomerModel model)
        {
            var response = new SaveCustomerResponse();
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
                response.Result = new Result(BaseResponseCodes.Success);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
               
            }
            
            return response;
        }
        public UpdateCustomerResponse UpdateCustomer(UpdateCustomerModel model)
        {
            var response = new UpdateCustomerResponse();
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
                response.Result = new Result(BaseResponseCodes.Success);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
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
