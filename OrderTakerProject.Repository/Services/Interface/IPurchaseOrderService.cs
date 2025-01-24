using OrderTakerProject.Core.Models.DatabaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Services.Interface
{
    public interface IPurchaseOrderService
    {
        public DbResult SavePurchaseOrder(SavePurchaseOrderModel model);
        public DbResult UpdatePurchaseOrder(UpdatePurchaseOrderModel model);
        public GetPurchaseOrderModel GetPurchaseOrderById(int id);
        public List<GetPurchaseOrderModel> GetPurchaseOrders();
    }
}
