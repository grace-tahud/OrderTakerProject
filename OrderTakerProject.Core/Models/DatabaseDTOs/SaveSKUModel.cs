using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DatabaseDTOs
{
    public class SaveSKUModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public byte[]? SKUImage { get; set; }
    }
    public class GetSKUModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public byte[]? SKUImage { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateSKUModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsActive { get; set; }
        public byte[]? SKUImage { get; set; }

    }
}
