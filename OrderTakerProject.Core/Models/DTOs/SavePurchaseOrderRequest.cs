using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class SavePurchaseOrderRequest
    {
        public int CustomerId { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string Status { get; set; }
        public decimal AmountDue { get; set; }
    }
    public class SavePurchaseOrderResponse:BaseResponse
    {
        public bool Success { get; set; }
    }
}
