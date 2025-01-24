using Microsoft.EntityFrameworkCore;
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
    public class PurchaseOrderService:IPurchaseOrderService,IDisposable
    {
        #region IDisposable implememtation
        private bool _disposed;
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

        private readonly ApplicationDbContext _context;
        public PurchaseOrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public DbResult SavePurchaseOrder(SavePurchaseOrderModel model)
        {
            var response = new DbResult();
            try
            {
                var dbResponse = _context.PurchaseOrders.Add(new PurchaseOrder
                {
                    CustomerId = model.CustomerId,
                    DateOfDelivery = model.DateOfDelivery,
                    Status = model.Status,
                    AmountDue = model.AmountDue,
                    IsActive = true
                });
                _context.SaveChanges();
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

        public DbResult UpdatePurchaseOrder(UpdatePurchaseOrderModel model)
        {
            var response = new DbResult();
            try
            {
                var customer = _context.PurchaseOrders.Where(c => c.Id == model.Id).FirstOrDefault();
                if (customer != null)
                {
                    customer.CustomerId = model.CustomerId;
                    customer.DateOfDelivery = model.DateOfDelivery;
                    customer.Status = model.Status;
                    customer.AmountDue = model.AmountDue;
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

        public GetPurchaseOrderModel GetPurchaseOrderById(int id)
        {
            var response = new GetPurchaseOrderModel();
            response = _context.PurchaseOrders.Where(o => o.Id == id).Include(o=>o.Customer).
                Select(o => new GetPurchaseOrderModel
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    CustomerName = o.Customer.FullName,
                    DateOfDelivery = o.DateOfDelivery,
                    Status = o.Status,
                    AmountDue = o.AmountDue,
                    IsActive = o.IsActive

                }).FirstOrDefault();
            ;
            return response;
        }

        public List<GetPurchaseOrderModel> GetPurchaseOrders()
        {
            var response = new List<GetPurchaseOrderModel>();
            response = _context.PurchaseOrders.Include(o=>o.Customer).
                Select(o => new GetPurchaseOrderModel
                {
                    Id = o.Id,
                    CustomerName = o.Customer.FullName,
                    CustomerId = o.CustomerId,
                    DateOfDelivery = o.DateOfDelivery,
                    Status = o.Status,
                    AmountDue = o.AmountDue,
                    IsActive = o.IsActive
                }).ToList();

            return response;
        }

    }
}
