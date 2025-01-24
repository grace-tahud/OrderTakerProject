using OrderTakerProject.Core.Models.DTOs;

namespace OrderTakerProject.UI.Models
{
    public class OrderViewModel
    {
        public List<PurchaseOrderModel> PurchaseOrders { get; set; }
        public PurchaseOrderModel PurchaseOrder { get; set; }

        public List<PurchaseItemModel> PurchaseItems { get; set; }
        public PurchaseItemModel PurchaseItem { get; set; }

        //public List<CustomerModel> Customers { get; set; }
        //public CustomerModel Customer { get; set; }
    }
}
