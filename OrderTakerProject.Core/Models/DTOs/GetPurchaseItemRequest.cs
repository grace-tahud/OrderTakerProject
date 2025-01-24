using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class GetPurchaseItemRequest
    {
        public int PurchaseItemId { get; set; }

    }
    public class GetPurchaseItemResponse
    {
        public PurchaseItemModel PurchaseItem { get; set; }
    }
}
