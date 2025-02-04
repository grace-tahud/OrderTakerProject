using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Core.Enumerations
{
    public enum BaseResponseCodes
    {
        [Description("Success")]
        Success = 0,
        [Description("No items retrieved.")]
        NoItems = 1,
        [Description("Error in connecting to host system.")]
        ErrorConnectHost = 98,

        [Description("Error encountered while processing the request.")]
        ErrorProcessingRequest = 99
    }
}
