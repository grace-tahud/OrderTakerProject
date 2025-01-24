using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class GetSKURequest
    {
        public int SKUId { get; set; }
        public string Name { get; set; }
    }
    public class GetSKUResponse
    {
        public SKUModel SKU { get; set; }
    }
}
