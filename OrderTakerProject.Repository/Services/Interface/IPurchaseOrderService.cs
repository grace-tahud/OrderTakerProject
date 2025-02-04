using OrderTakerProject.Core.Models.DatabaseDTOs;
using OrderTakerProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Services.Interface
{
    public interface IPurchaseOrderService
    {
        public SavePurchaseOrderResponse SavePurchaseOrder(SavePurchaseOrderModel model);
        public UpdatePurchaseOrderResponse UpdatePurchaseOrder(UpdatePurchaseOrderModel model);
        public GetPurchaseOrderResponse GetPurchaseOrderById(int id);
        public GetPurchaseOrdersResponse GetPurchaseOrders();
    }
}
