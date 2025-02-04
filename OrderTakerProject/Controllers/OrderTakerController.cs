using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [Route("SaveCustomer")]
        [HttpPost]
        public SaveCustomerResponse SaveCustomer(SaveCustomerRequest request)
        {
            var response = new SaveCustomerResponse();
            var model = mapper.Map<SaveCustomerModel>(request);
            var serviceResponse = customerService.SaveCustomer(model);
            response.Message = serviceResponse.Message;
            return response;
        }

        [Route("GetCustomers")]
        [HttpPost]
        public GetCustomersResponse GetCustomers()
        {
            var response = new GetCustomersResponse();
            //var model = mapper.Map<SaveCustomerModel>(request);
            var serviceResponse = customerService.GetCustomers();
            var customers = mapper.Map<List<CustomerModel>>(serviceResponse);
            response.Customers = customers;
            return response;
        }
        [Route("GetCustomerById")]
        [HttpPost]
        public GetCustomerResponse GetCustomerById(GetCustomerRequest request)
        {
            var response = new GetCustomerResponse();
            //var model = mapper.Map<SaveCustomerModel>(request);
            var serviceResponse = customerService.GetCustomerById(request.CustomerId);
            var customer = mapper.Map<CustomerModel>(serviceResponse);
            response.Customer = customer;
            return response;
        }
        [Route("GetCustomerByName")]
        [HttpPost]
        public GetCustomerResponse GetCustomerByName(GetCustomerRequest request)
        {
            var response = new GetCustomerResponse();
            //var model = mapper.Map<SaveCustomerModel>(request);
            var serviceResponse = customerService.GetCustomerByFullName(request.Name);
            var customer = mapper.Map<CustomerModel>(serviceResponse);
            response.Customer = customer;
            return response;
        }

        [Route("UpdateCustomer")]
        [HttpPost]
        public UpdateCustomerResponse UpdateCustomer(UpdateCustomerRequest request)
        {
            var response = new UpdateCustomerResponse();
            var model = mapper.Map<UpdateCustomerModel>(request);
            var serviceResponse = customerService.UpdateCustomer(model);
            response.Message = serviceResponse.Message;
            return response;
        }

        [Route("SaveSKU")]
        [HttpPost]
        public SaveSKUResponse SaveSKU(SaveSKURequest request)
        {
            var response = new SaveSKUResponse();
            var model = mapper.Map<SaveSKUModel>(request);
            var serviceResponse = skuService.SaveSKU(model);
            response.Message = serviceResponse.Message;
            return response;
        }

        [Route("GetSKUs")]
        [HttpPost]
        public GetSKUsResponse GetSKUs()
        {
            var response = new GetSKUsResponse();
            var serviceResponse = skuService.GetSKUs();
            var SKUs = mapper.Map<List<SKUModel>>(serviceResponse);
            response.SKUs = SKUs;
            return response;
        }

        [Route("GetSKUById")]
        [HttpPost]
        public GetSKUResponse GetSKUById(GetSKURequest request)
        {
            var response = new GetSKUResponse();
            var serviceResponse = skuService.GetSKUById(request.SKUId);
            var sku = mapper.Map<SKUModel>(serviceResponse);
            response.SKU = sku;
            return response;
        }

        [Route("GetSKUByName")]
        [HttpPost]
        public GetSKUResponse GetSKUByName(GetSKURequest request)
        {
            var response = new GetSKUResponse();
            var serviceResponse = skuService.GetSKUByName(request.Name);
            var sku = mapper.Map<SKUModel>(serviceResponse);
            response.SKU = sku;
            return response;
        }

        [Route("UpdateSKU")]
        [HttpPost]
        public UpdateSKUResponse UpdateSKU(UpdateSKURequest request)
        {
            var response = new UpdateSKUResponse();
            var model = mapper.Map<UpdateSKUModel>(request);
            var serviceResponse = skuService.UpdateSKU(model);
            response.Message = serviceResponse.Message;
            return response;
        }

        [Route("SavePurchaseOrder")]
        [HttpPost]
        public SavePurchaseOrderResponse SavePurchaseOrder(SavePurchaseOrderRequest request)
        {
            var response = new SavePurchaseOrderResponse();
            var model = mapper.Map<SavePurchaseOrderModel>(request);
            var serviceResponse = purchaseOrderService.SavePurchaseOrder(model);
            response.Message = serviceResponse.Message;
            return response;
        }

        [Route("GetPurchaseOrders")]
        [HttpPost]
        public GetPurchaseOrdersResponse GetPurchaseOrders()
        {
            var response = new GetPurchaseOrdersResponse();
            var serviceResponse = purchaseOrderService.GetPurchaseOrders();
            var PurchaseOrders = mapper.Map<List<PurchaseOrderModel>>(serviceResponse);
            response.PurchaseOrders = PurchaseOrders;
            return response;
        }

        [Route("GetPurchaseOrderById")]
        [HttpPost]
        public GetPurchaseOrderResponse GetPurchaseOrderById(GetPurchaseOrderRequest request)
        {
            var response = new GetPurchaseOrderResponse();
            var serviceResponse = purchaseOrderService.GetPurchaseOrderById(request.PurchaseOrderId);
            var PurchaseOrder = mapper.Map<PurchaseOrderModel>(serviceResponse);
            response.PurchaseOrder = PurchaseOrder;
            return response;
        }

        [Route("UpdatePurchaseOrder")]
        [HttpPost]
        public UpdatePurchaseOrderResponse UpdatePurchaseOrder(UpdatePurchaseOrderRequest request)
        {
            var response = new UpdatePurchaseOrderResponse();
            var model = mapper.Map<UpdatePurchaseOrderModel>(request);
            var serviceResponse = purchaseOrderService.UpdatePurchaseOrder(model);
            response.Message = serviceResponse.Message;
            return response;
        }

        [Route("SavePurchaseItem")]
        [HttpPost]
        public SavePurchaseItemResponse SavePurchaseItem(SavePurchaseItemRequest request)
        {
            var response = new SavePurchaseItemResponse();
            var model = mapper.Map<SavePurchaseItemModel>(request);
            var serviceResponse = purchaseItemService.SavePurchaseItem(model);
            if(serviceResponse.Success)
            {
                response.Code = 0;
            }
            else { response.Code = 99; }
            response.Message = serviceResponse.Message;
            return response;
        }

        [Route("GetPurchaseItems")]
        [HttpPost]
        public GetPurchaseItemsResponse GetPurchaseItems()
        {
            var response = new GetPurchaseItemsResponse();
            var serviceResponse = purchaseItemService.GetPurchaseItems();
            var PurchaseItems = mapper.Map<List<PurchaseItemModel>>(serviceResponse);
            response.PurchaseItems = PurchaseItems;
            return response;
        }
        [Route("GetPurchaseItemsByOrder")]
        [HttpPost]
        public GetPurchaseItemsResponse GetPurchaseItemsByOrder(GetPurchaseItemsRequest request)
        {
            var response = new GetPurchaseItemsResponse();
            var serviceResponse = purchaseItemService.GetPurchaseItemsByOrder(request.PurchaseOrderId);
            var PurchaseItems = mapper.Map<List<PurchaseItemModel>>(serviceResponse);
            response.PurchaseItems = PurchaseItems;
            response.TotalPurchaseAmount = PurchaseItems.Sum(i=>i.Price);
            return response;
        }

        [Route("GetPurchaseItemById")]
        [HttpPost]
        public GetPurchaseItemResponse GetPurchaseItemById(GetPurchaseItemRequest request)
        {
            var response = new GetPurchaseItemResponse();
            var serviceResponse = purchaseItemService.GetPurchaseItemById(request.PurchaseItemId);
            var PurchaseItem = mapper.Map<PurchaseItemModel>(serviceResponse);
            response.PurchaseItem = PurchaseItem;
            return response;
        }

        [Route("UpdatePurchaseItem")]
        [HttpPost]
        public UpdatePurchaseItemResponse UpdatePurchaseItem(UpdatePurchaseItemRequest request)
        {
            var response = new UpdatePurchaseItemResponse();
            var model = mapper.Map<UpdatePurchaseItemModel>(request);
            var serviceResponse = purchaseItemService.UpdatePurchaseItem(model);
            response.Message = serviceResponse.Message;
            return response;
        }
    }
}
