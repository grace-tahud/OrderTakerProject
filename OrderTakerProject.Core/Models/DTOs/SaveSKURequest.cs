using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class SaveSKURequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public byte[]? SKUImage { get; set; }
    }
    public class SaveSKUResponse:BaseResponse
    {
        public bool Success { get; set; }
    }
}
