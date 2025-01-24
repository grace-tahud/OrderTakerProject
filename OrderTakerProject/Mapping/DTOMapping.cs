using AutoMapper;
using OrderTakerProject.Core.Models.DatabaseDTOs;
using OrderTakerProject.Core.Models.DTOs;

namespace OrderTakerProject.Mapping
{
    public class DTOMapping:Profile
    {
        public DTOMapping()
        {
            //Customers
            CreateMap<GetCustomerModel, CustomerModel>();
            CreateMap<SaveCustomerRequest, SaveCustomerModel>();
            CreateMap<UpdateCustomerRequest, UpdateCustomerModel>();

            //SKUs
            CreateMap<SaveSKURequest, SaveSKUModel>();
            CreateMap<GetSKUModel, SKUModel>();
            CreateMap<UpdateSKURequest, UpdateSKUModel>();

            //PurchaseOrders
            CreateMap<SavePurchaseOrderRequest, SavePurchaseOrderModel>();
            CreateMap<GetPurchaseOrderModel, PurchaseOrderModel>();
            CreateMap<UpdatePurchaseOrderRequest, UpdatePurchaseOrderModel>();

            //PurchaseItems
            CreateMap<SavePurchaseItemRequest, SavePurchaseItemModel>();
            CreateMap<GetPurchaseItemModel, PurchaseItemModel>();
            CreateMap<UpdatePurchaseItemRequest, UpdatePurchaseItemModel>();
        }
    }
}
