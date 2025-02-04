using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class UpdateSKURequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public byte[]? SKUImage { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateSKUResponse:BaseResponse
    {
        public bool Success { get; set; }
    }
}
