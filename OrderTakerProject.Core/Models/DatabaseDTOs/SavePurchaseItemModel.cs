using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DatabaseDTOs
{
    public class SavePurchaseItemModel
    {
        public int PurchaseOrderId { get; set; }
        public int SKUId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
    public class GetPurchaseItemModel
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int SKUId { get; set; }
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
    public class UpdatePurchaseItemModel
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int SKUId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
