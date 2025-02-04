using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderTakerProject.Core.Enumerations;
using OrderTakerProject.Core.Models.DatabaseDTOs;
using OrderTakerProject.Core.Models.DTOs;
using OrderTakerProject.Repository.Services.Interface;

namespace OrderTakerProject.Controllers
{
    [Route("api/order/taker")]
    [ApiController]
    public class OrderTakerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly ISKUService skuService;
        private readonly IPurchaseOrderService purchaseOrderService;
        private readonly IPurchaseItemService purchaseItemService;
        private readonly IMapper mapper;

        public OrderTakerController(ICustomerService customerService,
            ISKUService skuService,
            IPurchaseOrderService purchaseOrderService,
            IPurchaseItemService purchaseItemService,
            IMapper mapper)
        {
            this.customerService = customerService;
            this.skuService = skuService;
            this.purchaseOrderService = purchaseOrderService;
            this.purchaseItemService = purchaseItemService;
            this.mapper = mapper;
        }

        #region Customers
        [Route("SaveCustomer")]
        [HttpPost]
        public SaveCustomerResponse SaveCustomer(SaveCustomerRequest request)
        {
            var response = new SaveCustomerResponse();
            try
            {
                var model = mapper.Map<SaveCustomerModel>(request);
                response = customerService.SaveCustomer(model);
            }
            catch(Exception ex)
            {
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
           
            return response;
        }

        [Route("UpdateCustomer")]
        [HttpPost]
        public UpdateCustomerResponse UpdateCustomer(UpdateCustomerRequest request)
        {
            var response = new UpdateCustomerResponse();
            try
            {
                var model = mapper.Map<UpdateCustomerModel>(request);
                response = customerService.UpdateCustomer(model);

            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };
            }
            return response;
        }

        [Route("GetCustomers")]
        [HttpPost]
        public GetCustomersResponse GetCustomers()
        {
            var response = new GetCustomersResponse();
            try
            {
                response = customerService.GetCustomers();
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };
            }
            return response;
        }

        [Route("GetCustomerById")]
        [HttpPost]
        public GetCustomerResponse GetCustomerById(GetCustomerRequest request)
        {
            var response = new GetCustomerResponse();
            try
            {
                response = customerService.GetCustomerById(request.CustomerId);
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };
            }
            return response;
        }

        [Route("GetCustomerByName")]
        [HttpPost]
        public GetCustomerResponse GetCustomerByName(GetCustomerRequest request)
        {
            var response = new GetCustomerResponse();
            try
            {
                response = customerService.GetCustomerByFullName(request.Name);
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };
            }
            return response;
        }

        #endregion

        [Route("SaveSKU")]
        [HttpPost]
        public SaveSKUResponse SaveSKU(SaveSKURequest request)
        {
            var response = new SaveSKUResponse();
            try
            {
                var model = mapper.Map<SaveSKUModel>(request);
                response = skuService.SaveSKU(model);
            }
            catch(Exception ex)
            {
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
           
            return response;
        }
        [Route("UpdateSKU")]
        [HttpPost]
        public UpdateSKUResponse UpdateSKU(UpdateSKURequest request)
        {
            var response = new UpdateSKUResponse();
            try
            {
                var model = mapper.Map<UpdateSKUModel>(request);
                response = skuService.UpdateSKU(model);
            }
            catch (Exception ex)
            {
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
            return response;
        }

        [Route("GetSKUs")]
        [HttpPost]
        public GetSKUsResponse GetSKUs()
        {
            var response = new GetSKUsResponse();
            try
            {
                response = skuService.GetSKUs();
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };
            }
            //var serviceResponse = skuService.GetSKUs();
            //var SKUs = mapper.Map<List<SKUModel>>(serviceResponse);
            //response.SKUs = SKUs;
            return response;
        }

        [Route("GetSKUById")]
        [HttpPost]
        public GetSKUResponse GetSKUById(GetSKURequest request)
        {
            var response = new GetSKUResponse();
            try
            {
                response = skuService.GetSKUById(request.SKUId);
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };

            }
            //var serviceResponse = skuService.GetSKUById(request.SKUId);
            //var sku = mapper.Map<SKUModel>(serviceResponse);
            //response.SKU = sku;
            return response;
        }

        [Route("GetSKUByName")]
        [HttpPost]
        public GetSKUResponse GetSKUByName(GetSKURequest request)
        {
            var response = new GetSKUResponse();
            try
            {
                response = skuService.GetSKUByName(request.Name);
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };
            }
            //var serviceResponse = skuService.GetSKUByName(request.Name);
            //var sku = mapper.Map<SKUModel>(serviceResponse);
            //response.SKU = sku;
            return response;
        }

        

        [Route("SavePurchaseOrder")]
        [HttpPost]
        public SavePurchaseOrderResponse SavePurchaseOrder(SavePurchaseOrderRequest request)
        {
            var response = new SavePurchaseOrderResponse();

            try
            {
                var model = mapper.Map<SavePurchaseOrderModel>(request);
                response = purchaseOrderService.SavePurchaseOrder(model);
            }
            catch (Exception ex)
            {
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }

            return response;
        }

        [Route("UpdatePurchaseOrder")]
        [HttpPost]
        public UpdatePurchaseOrderResponse UpdatePurchaseOrder(UpdatePurchaseOrderRequest request)
        {
            var response = new UpdatePurchaseOrderResponse();
            try
            {
                var model = mapper.Map<UpdatePurchaseOrderModel>(request);
                response = purchaseOrderService.UpdatePurchaseOrder(model);
            }
            catch (Exception ex)
            {
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }

            return response;
        }
        [Route("GetPurchaseOrders")]
        [HttpPost]
        public GetPurchaseOrdersResponse GetPurchaseOrders()
        {
            var response = new GetPurchaseOrdersResponse();

            try
            {
                response = purchaseOrderService.GetPurchaseOrders();
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };
            }
            return response;
        }

        [Route("GetPurchaseOrderById")]
        [HttpPost]
        public GetPurchaseOrderResponse GetPurchaseOrderById(GetPurchaseOrderRequest request)
        {
            var response = new GetPurchaseOrderResponse();

            try
            {
                response = purchaseOrderService.GetPurchaseOrderById(request.PurchaseOrderId);
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };

            }

            //var serviceResponse = purchaseOrderService.GetPurchaseOrderById(request.PurchaseOrderId);
            //var PurchaseOrder = mapper.Map<PurchaseOrderModel>(serviceResponse);
            //response.PurchaseOrder = PurchaseOrder;
            return response;
        }

        

        [Route("SavePurchaseItem")]
        [HttpPost]
        public SavePurchaseItemResponse SavePurchaseItem(SavePurchaseItemRequest request)
        {
            var response = new SavePurchaseItemResponse();

            try
            {
                var model = mapper.Map<SavePurchaseItemModel>(request);
                response = purchaseItemService.SavePurchaseItem(model);
            }
            catch (Exception ex)
            {
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
           
            return response;
        }

        [Route("UpdatePurchaseItem")]
        [HttpPost]
        public UpdatePurchaseItemResponse UpdatePurchaseItem(UpdatePurchaseItemRequest request)
        {
            var response = new UpdatePurchaseItemResponse();
            try
            {
                var model = mapper.Map<UpdatePurchaseItemModel>(request);
                response = purchaseItemService.UpdatePurchaseItem(model);
            }
            catch (Exception ex)
            {
                response.Result = new Result(BaseResponseCodes.ErrorProcessingRequest);
            }
            return response;
        }

        [Route("GetPurchaseItems")]
        [HttpPost]
        public GetPurchaseItemsResponse GetPurchaseItems()
        {
            var response = new GetPurchaseItemsResponse();
            try
            {
                response = purchaseItemService.GetPurchaseItems();
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };
            }

            //var serviceResponse = purchaseItemService.GetPurchaseItems();
            //var PurchaseItems = mapper.Map<List<PurchaseItemModel>>(serviceResponse);
            //response.PurchaseItems = PurchaseItems;
            return response;
        }
        [Route("GetPurchaseItemsByOrder")]
        [HttpPost]
        public GetPurchaseItemsResponse GetPurchaseItemsByOrder(GetPurchaseItemsRequest request)
        {
            var response = new GetPurchaseItemsResponse();

            try
            {
                response = purchaseItemService.GetPurchaseItemsByOrder(request.PurchaseOrderId);
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };
            }

            //var serviceResponse = purchaseItemService.GetPurchaseItemsByOrder(request.PurchaseOrderId);
            //var PurchaseItems = mapper.Map<List<PurchaseItemModel>>(serviceResponse);
            //response.PurchaseItems = PurchaseItems;
            //response.TotalPurchaseAmount = PurchaseItems.Sum(i=>i.Price);
            return response;
        }

        [Route("GetPurchaseItemById")]
        [HttpPost]
        public GetPurchaseItemResponse GetPurchaseItemById(GetPurchaseItemRequest request)
        {
            var response = new GetPurchaseItemResponse();

            try
            {
                response = purchaseItemService.GetPurchaseItemById(request.PurchaseItemId);
            }
            catch (Exception ex)
            {
                response.Result = new Result
                {
                    Code = BaseResponseCodes.ErrorProcessingRequest.ToInt(),
                    Description = $"{BaseResponseCodes.ErrorProcessingRequest.StringValue()} {ex.Message}"
                };

            }

            //var serviceResponse = purchaseItemService.GetPurchaseItemById(request.PurchaseItemId);
            //var PurchaseItem = mapper.Map<PurchaseItemModel>(serviceResponse);
            //response.PurchaseItem = PurchaseItem;
            return response;
        }

       
    }
}
