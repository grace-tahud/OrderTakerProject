
using OrderTakerProject.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Models.Entity
{
    public class PurchaseOrder:BaseEntity
    {
        public int CustomerId { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string Status { get; set; } = Constants.PurchaseOrderStatus.New;
        public decimal AmountDue { get; set; }
        public bool IsActive { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
