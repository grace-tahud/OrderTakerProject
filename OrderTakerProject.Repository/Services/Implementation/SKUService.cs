using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class SKUService:ISKUService, IDisposable
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SKUService(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public GetSKUResponse GetSKUById(int id)
        {
            var response = new GetSKUResponse();
            try
            {
                var dbResponse = _context.SKUs.Where(s => s.Id == id).FirstOrDefault();
                if (dbResponse != null)
                {
                    var skuModel = _mapper.Map<SKUModel>(dbResponse);
                    response.SKU = skuModel;
                    response.Success = true;
                    response.Result = new Result(BaseResponseCodes.Success);
                }

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
            //response = _context.SKUs.Where(s => s.Id == id).
            //    Select(s => new GetSKUModel
            //    {
            //        Id = s.Id,
            //        Name = s.Name,
            //        Code = s.Code,
            //        UnitPrice = s.UnitPrice,
            //        IsActive = s.IsActive,
            //        SKUImage = s.SKUImage

            //    }).FirstOrDefault();
            //;
            return response;
        }
        public GetSKUResponse GetSKUByName(string name)
        {
            var response = new GetSKUResponse();
            try
            {
                var dbResponse = _context.SKUs.Where(s => s.Name.Contains(name)).FirstOrDefault();
                if (dbResponse != null)
                {
                    var skuModel = _mapper.Map<SKUModel>(dbResponse);
                    response.SKU = skuModel;
                    response.Success = true;
                    response.Result = new Result(BaseResponseCodes.Success);
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
            //response = _context.SKUs.Where(s => s.Name.Contains(name)).
            //    Select(s => new GetSKUModel
            //    {
            //        Id = s.Id,
            //        Name = s.Name,
            //        Code = s.Code,
            //        UnitPrice = s.UnitPrice,
            //        //IsActive = s.IsActive,
            //        //SKUImage = s.SKUImage

            //    }).FirstOrDefault();
            //;
            return response;
        }
        public GetSKUsResponse GetSKUs()
        {
            var response = new GetSKUsResponse();
            try
            {
                var dbResponse = _context.SKUs.ToList();
                if (dbResponse != null)
                {
                    var skusModel = _mapper.Map<List<SKUModel>>(dbResponse);
                    response.SKUs = skusModel;
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
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
            //response = _context.SKUs.
            //    Select(s => new GetSKUModel
            //    {
            //        Id = s.Id,
            //        Name = s.Name,
            //        Code = s.Code,
            //        UnitPrice = s.UnitPrice,
            //        IsActive = s.IsActive,
            //        SKUImage = s.SKUImage
            //    }).ToList();

            return response;
        }

        public SaveSKUResponse SaveSKU(SaveSKUModel model)
        {
            var response = new SaveSKUResponse();
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
                response.Result = new Result(BaseResponseCodes.Success);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }

            return response;
        }

        public UpdateSKUResponse UpdateSKU(UpdateSKUModel model)
        {
            var response = new UpdateSKUResponse();
            try
            {
                var sku = _context.SKUs.Where(c => c.Id == model.Id).FirstOrDefault();
                if (sku != null)
                {
                    sku.Name = model.Name;
                    sku.Code = model.Code;
                    sku.UnitPrice = model.UnitPrice;
                    sku.SKUImage = model.SKUImage;
                    sku.IsActive = model.IsActive;
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

        
    }
}
