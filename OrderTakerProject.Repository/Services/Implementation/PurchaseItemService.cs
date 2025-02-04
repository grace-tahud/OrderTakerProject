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
        private readonly IMapper _mapper;
        public PurchaseItemService(ApplicationDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SavePurchaseItemResponse SavePurchaseItem(SavePurchaseItemModel model)
        {
            var response = new SavePurchaseItemResponse();
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
                response.Result = new Result(BaseResponseCodes.Success);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }

            return response;
        }

        public UpdatePurchaseItemResponse UpdatePurchaseItem(UpdatePurchaseItemModel model)
        {
            var response = new UpdatePurchaseItemResponse();
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
                response.Result = new Result(BaseResponseCodes.Success);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }

            return response;
        }

        public GetPurchaseItemResponse GetPurchaseItemById(int id)
        {
            var response = new GetPurchaseItemResponse();
            try
            {
                var dbResponse = _context.PurchaseItems.Where(i => i.Id == id).Include(i => i.SKU).FirstOrDefault();
                if (dbResponse != null)
                {
                    var purchaseItemModel = _mapper.Map<PurchaseItemModel>(dbResponse);
                    response.PurchaseItem = purchaseItemModel;
                    response.Success = true;
                    response.Result = new Result(BaseResponseCodes.Success);
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
            //response = _context.PurchaseItems.Where(i => i.Id == id).Include(i=>i.SKU).
            //    Select(i => new GetPurchaseItemModel
            //    {
            //        Id=i.Id,
            //        PurchaseOrderId = i.PurchaseOrderId,
            //        SKU = i.SKU.Name,
            //        SKUId = i.SKUId,
            //        Quantity = i.Quantity,
            //        UnitPrice = i.SKU.UnitPrice,
            //        Price = i.Price

            //    }).FirstOrDefault();
            //;
            return response;
        }

        public GetPurchaseItemsResponse GetPurchaseItems()
        {
            var response = new GetPurchaseItemsResponse();
            try
            {
                var dbResponse = _context.PurchaseItems.Include(i => i.SKU).ToList();
                if (dbResponse != null)
                {
                    var purchaseItemsModel = _mapper.Map<List<PurchaseItemModel>>(dbResponse);
                    response.PurchaseItems = purchaseItemsModel;
                    response.TotalPurchaseAmount = purchaseItemsModel.Sum(i => i.Price);
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
            catch (Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
            //
            //response = _context.PurchaseItems.Include(i => i.SKU).
            //    Select(i => new GetPurchaseItemModel
            //    {
            //        Id = i.Id,
            //        PurchaseOrderId = i.PurchaseOrderId,
            //        SKUId = i.SKUId,
            //        SKU = i.SKU.Name,
            //        UnitPrice = i.SKU.UnitPrice,
            //        Quantity = i.Quantity,
            //        Price = i.Price
            //    }).ToList();

            return response;
        }

        public GetPurchaseItemsResponse GetPurchaseItemsByOrder(int purchaseOrderId)
        {
            var response = new GetPurchaseItemsResponse();
            try
            {
                var dbResponse = _context.PurchaseItems.Where(i => i.PurchaseOrderId == purchaseOrderId).Include(i => i.SKU).ToList();
                if (dbResponse != null)
                {
                    var purchaseItemsModel = _mapper.Map<List<PurchaseItemModel>>(dbResponse);
                    response.PurchaseItems = purchaseItemsModel;
                    response.TotalPurchaseAmount = purchaseItemsModel.Sum(i => i.Price);
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
            catch (Exception ex)
            {
                response.Success = false;
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
            //var response = new List<GetPurchaseItemModel>();
            //response = _context.PurchaseItems.Where(i=>i.PurchaseOrderId == purchaseOrderId).Include(i=>i.SKU).
                
            //    Select(i => new GetPurchaseItemModel
            //    {
            //        Id = i.Id,
            //        PurchaseOrderId = i.PurchaseOrderId,
            //        UnitPrice = i.SKU.UnitPrice,
            //        SKUId = i.SKUId,
            //        SKU = i.SKU.Name,
            //        Quantity = i.Quantity,
            //        Price = i.Price
            //    }).ToList();

            return response;
        }
    }
}
