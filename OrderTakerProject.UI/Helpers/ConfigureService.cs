using OrderTakerProject.UI.Services.Implementation;
using OrderTakerProject.UI.Services.Interface;

namespace OrderTakerProject.UI.Helpers
{
    public static class ConfigureService
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDashboardService, DashboardService>();
        }
    }
}
