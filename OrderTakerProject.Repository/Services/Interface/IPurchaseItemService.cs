using OrderTakerProject.Core.Models.DatabaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Services.Interface
{
    public interface IPurchaseItemService
    {
        public DbResult SavePurchaseItem(SavePurchaseItemModel model);
        public DbResult UpdatePurchaseItem(UpdatePurchaseItemModel model);
        public GetPurchaseItemModel GetPurchaseItemById(int id);
        public List<GetPurchaseItemModel> GetPurchaseItems();
        public List<GetPurchaseItemModel> GetPurchaseItemsByOrder(int purchaseOrderId);
    }
}
