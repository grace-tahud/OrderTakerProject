using OrderTakerProject.Core.Models.DatabaseDTOs;
using OrderTakerProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Services.Interface
{
    public interface IPurchaseItemService
    {
        public SavePurchaseItemResponse SavePurchaseItem(SavePurchaseItemModel model);
        public UpdatePurchaseItemResponse UpdatePurchaseItem(UpdatePurchaseItemModel model);
        public GetPurchaseItemResponse GetPurchaseItemById(int id);
        public GetPurchaseItemsResponse GetPurchaseItems();
        public GetPurchaseItemsResponse GetPurchaseItemsByOrder(int purchaseOrderId);
    }
}
