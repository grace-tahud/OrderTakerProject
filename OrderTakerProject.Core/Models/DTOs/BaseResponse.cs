using OrderTakerProject.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Models.DTOs
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public Result? Result { get; set; }
    }
    public class Result
    {
        public int Code { get; set; }
        public string Description { get; set; }

        public Result()
        {

        }
        public Result(Result result)
        {
            Code = result.Code;
            Description = result.Description;
        }

        public Result(BaseResponseCodes code)
        {
            Code = code.ToInt();
            string description = code.StringValue();
            Description = description.Contains("{") ? String.Format(description, $"Code {code}.") : description;
        }
    }
}
