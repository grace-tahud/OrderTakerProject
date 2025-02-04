using OrderTakerProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DatabaseDTOs
{
    public class DbResult:BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
