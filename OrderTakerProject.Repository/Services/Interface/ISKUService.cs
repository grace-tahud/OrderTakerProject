using OrderTakerProject.Core.Models.DatabaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTakerProject.Repository.Services.Interface
{
    public interface ISKUService
    {
        public DbResult SaveSKU(SaveSKUModel model);
        public DbResult UpdateSKU(UpdateSKUModel model);
        public GetSKUModel GetSKUById(int id);
        public GetSKUModel GetSKUByName(string name);
        public List<GetSKUModel> GetSKUs();
    }
}
