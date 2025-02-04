using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class GetPurchaseOrderRequest
    {
        public int PurchaseOrderId { get; set; }
    }

    public class GetPurchaseOrderResponse:BaseResponse
    {
        public PurchaseOrderModel PurchaseOrder { get; set; }
    }
}
