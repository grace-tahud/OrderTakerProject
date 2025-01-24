using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class SavePurchaseItemRequest
    {
        public int PurchaseOrderId { get; set; }
        public int SKUId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
    public class SavePurchaseItemResponse
    {
        public string Message { get; set; }
    }
}
