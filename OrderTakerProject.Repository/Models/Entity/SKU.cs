using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Models.Entity
{
    public class SKU:BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsActive { get; set; } = true;
        public byte[]? SKUImage { get; set; }
    }
}
