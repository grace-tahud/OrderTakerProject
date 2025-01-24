using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DatabaseDTOs
{
    public class SavePurchaseOrderModel
    {
        public int CustomerId { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string Status { get; set; } 
        public decimal AmountDue { get; set; }
    }
    public class GetPurchaseOrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string Status { get; set; }
        public decimal AmountDue { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdatePurchaseOrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string Status { get; set; }
        public decimal AmountDue { get; set; }
        public bool IsActive { get; set; }

    }
}
