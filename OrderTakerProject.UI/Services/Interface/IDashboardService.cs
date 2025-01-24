
using OrderTakerProject.Core.Models.DTOs;
using OrderTakerProject.UI.Models;

namespace OrderTakerProject.UI.Services.Interface
{
    public interface IDashboardService
    {
        public Task<CustomerViewModel> GetCustomers();
        public Task<SKUViewModel> GetSkus();
        public Task<OrderViewModel> GetOrders();
        public Task<PurchaseItemViewModel> GetItems(int purchaseOrderId);
        public Task<OrderViewModel> GetExistingOrder(int purchaseOrderId);
    }
}
