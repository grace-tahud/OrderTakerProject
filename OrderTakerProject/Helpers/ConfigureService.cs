using OrderTakerProject.Repository.Services.Implementation;
using OrderTakerProject.Repository.Services.Interface;

namespace OrderTakerProject.Helpers
{
    public static class ConfigureService
    {
        public static void ConfigureServices(WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<ICustomerService,CustomerService>();
            builder.Services.AddScoped<ISKUService, SKUService>();
            builder.Services.AddScoped<IPurchaseOrderService,PurchaseOrderService>();
            builder.Services.AddScoped<IPurchaseItemService,PurchaseItemService>();
        }
    }
}
