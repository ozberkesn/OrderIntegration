using OrderIntegration.ACompany.Web.Models;
using OrderIntegration.ACompany.Web.Services;
using OrderIntegration.ACompany.Web.Services.Interfaces;

namespace OrderIntegration.ACompany.Web.Extensions
{
    public static class ServiceExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
        {
            var serviceApiSettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            services.AddHttpClient<IOrderService, OrderService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Order.Path}");
            });
        }
    }
}
