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
    public class PurchaseItemService:IPurchaseItemService, IDisposable
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
        public PurchaseItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbResult SavePurchaseItem(SavePurchaseItemModel model)
        {
            var response = new DbResult();
            try
            {
                var dbResponse = _context.PurchaseItems.Add(new PurchaseItem
                {
                    PurchaseOrderId = model.PurchaseOrderId,
                    SKUId = model.SKUId,
                    Quantity = model.Quantity,
                    Price = model.Price
                   
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

        public DbResult UpdatePurchaseItem(UpdatePurchaseItemModel model)
        {
            var response = new DbResult();
            try
            {
                var purchaseItem = _context.PurchaseItems.Where(c => c.Id == model.Id).FirstOrDefault();
                if (purchaseItem != null)
                {
                    purchaseItem.PurchaseOrderId = model.PurchaseOrderId;
                    purchaseItem.SKUId = model.SKUId;
                    purchaseItem.Quantity =model.Quantity;
                    purchaseItem.Price = model.Price;
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

        public GetPurchaseItemModel GetPurchaseItemById(int id)
        {
            var response = new GetPurchaseItemModel();
            response = _context.PurchaseItems.Where(i => i.Id == id).Include(i=>i.SKU).
                Select(i => new GetPurchaseItemModel
                {
                    Id=i.Id,
                    PurchaseOrderId = i.PurchaseOrderId,
                    SKU = i.SKU.Name,
                    SKUId = i.SKUId,
                    Quantity = i.Quantity,
                    UnitPrice = i.SKU.UnitPrice,
                    Price = i.Price

                }).FirstOrDefault();
            ;
            return response;
        }

        public List<GetPurchaseItemModel> GetPurchaseItems()
        {
            var response = new List<GetPurchaseItemModel>();
            response = _context.PurchaseItems.Include(i => i.SKU).
                Select(i => new GetPurchaseItemModel
                {
                    Id = i.Id,
                    PurchaseOrderId = i.PurchaseOrderId,
                    SKUId = i.SKUId,
                    SKU = i.SKU.Name,
                    UnitPrice = i.SKU.UnitPrice,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList();

            return response;
        }

        public List<GetPurchaseItemModel> GetPurchaseItemsByOrder(int purchaseOrderId)
        {
            var response = new List<GetPurchaseItemModel>();
            response = _context.PurchaseItems.Where(i=>i.PurchaseOrderId == purchaseOrderId).Include(i=>i.SKU).
                
                Select(i => new GetPurchaseItemModel
                {
                    Id = i.Id,
                    PurchaseOrderId = i.PurchaseOrderId,
                    UnitPrice = i.SKU.UnitPrice,
                    SKUId = i.SKUId,
                    SKU = i.SKU.Name,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList();

            return response;
        }
    }
}
