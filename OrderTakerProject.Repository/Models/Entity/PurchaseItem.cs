using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Models.Entity
{
    public class PurchaseItem:BaseModel
    {
        public int PurchaseOrderId { get; set; }
        public int SKUId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual SKU SKU { get; set; }

    }
}
