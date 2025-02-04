using AutoMapper;
using OrderTakerProject.Core.Models.DatabaseDTOs;
using OrderTakerProject.Core.Models.DTOs;
using OrderTakerProject.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Mapping
{
    public class EntityMapping:Profile
    {
        public EntityMapping()
        {
            //Customers
            CreateMap<Customer, CustomerModel>();

            //SKU
            CreateMap<SKU, SKUModel>();

            //PurchaseOrder
            CreateMap<PurchaseOrder, PurchaseOrderModel>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName));

            //PurchaseItem
            CreateMap<PurchaseItem, PurchaseItemModel>()
                .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.SKU.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.SKU.UnitPrice));

            //CreateMap<PurchaseItem, PurchaseItemModel>()
            //   .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.SKU.UnitPrice));
        }
    }
}
