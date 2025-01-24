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
    public class SKUService:ISKUService, IDisposable
    {

        private readonly ApplicationDbContext _context;
        public SKUService(ApplicationDbContext context)
        {
            _context = context;
        }
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

        public GetSKUModel GetSKUById(int id)
        {
            var response = new GetSKUModel();
            response = _context.SKUs.Where(s => s.Id == id).
                Select(s => new GetSKUModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Code = s.Code,
                    UnitPrice = s.UnitPrice,
                    IsActive = s.IsActive,
                    SKUImage = s.SKUImage

                }).FirstOrDefault();
            ;
            return response;
        }
        public GetSKUModel GetSKUByName(string name)
        {
            var response = new GetSKUModel();
            response = _context.SKUs.Where(s => s.Name.Contains(name)).
                Select(s => new GetSKUModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Code = s.Code,
                    UnitPrice = s.UnitPrice,
                    //IsActive = s.IsActive,
                    //SKUImage = s.SKUImage

                }).FirstOrDefault();
            ;
            return response;
        }
        public List<GetSKUModel> GetSKUs()
        {
            var response = new List<GetSKUModel>();
            response = _context.SKUs.
                Select(s => new GetSKUModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Code = s.Code,
                    UnitPrice = s.UnitPrice,
                    IsActive = s.IsActive,
                    SKUImage = s.SKUImage
                }).ToList();

            return response;
        }

        public DbResult SaveSKU(SaveSKUModel model)
        {
            var response = new DbResult();
            try
            {
                var dbResponse = _context.SKUs.Add(new SKU
                {
                    Name = model.Name,
                    Code = model.Code,
                    UnitPrice = model.UnitPrice,
                    SKUImage = model.SKUImage

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

        public DbResult UpdateSKU(UpdateSKUModel model)
        {
            var response = new DbResult();
            try
            {
                var customer = _context.SKUs.Where(c => c.Id == model.Id).FirstOrDefault();
                if (customer != null)
                {
                    customer.Name = model.Name;
                    customer.Code = model.Code;
                    customer.UnitPrice = model.UnitPrice;
                    customer.SKUImage = model.SKUImage;
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

        
    }
}
