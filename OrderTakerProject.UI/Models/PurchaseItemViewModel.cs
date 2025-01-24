using OrderTakerProject.Core.Models.DTOs;

namespace OrderTakerProject.UI.Models
{
    public class PurchaseItemViewModel
    {
        public List<PurchaseItemModel> PurchaseItems { get; set; }
        public PurchaseItemModel PurchaseItem { get; set; }
    }
}
