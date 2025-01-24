using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class GetPurchaseItemsRequest
    {
        public int PurchaseOrderId { get; set; }
    }
    public class GetPurchaseItemsResponse
    {
        public List<PurchaseItemModel> PurchaseItems { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
    }
    public class PurchaseItemModel
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public string SKU { get; set; }
        public int SKUId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
