using OrderTakerProject.Core.Models.DatabaseDTOs;
using OrderTakerProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Services.Interface
{
    public interface ISKUService
    {
        public SaveSKUResponse SaveSKU(SaveSKUModel model);
        public UpdateSKUResponse UpdateSKU(UpdateSKUModel model);
        public GetSKUResponse GetSKUById(int id);
        public GetSKUResponse GetSKUByName(string name);
        public GetSKUsResponse GetSKUs();
    }
}
