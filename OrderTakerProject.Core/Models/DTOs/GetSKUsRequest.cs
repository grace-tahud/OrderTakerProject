using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class GetSKUsRequest
    {
    }
    public class GetSKUsResponse:BaseResponse
    {
        public List<SKUModel> SKUs { get; set; }
    }
    public class SKUModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public byte[]? SKUImage { get; set; }
        public bool IsActive { get; set; }
    }
}
