using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderIntegration.ACompany.Services.OrderManager.Domain.OrderAggregate;

namespace OrderIntegration.ACompany.Services.OrderManager.Infrastructure
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<OrderDBContext>();
                context.Database.Migrate();

                if (!context.Orders.Any())
                {
                    context.AddRange(new List<Order>
                        {
                            new Order()
                            {
                                IntegrationId = 101,
                                OrderStatusId = 2,
                                ReceiverAddress = "ALICI ADRESİ 101",
                                ReceiverName = "ALICI 101",
                            },
                            new Order
                            {
                                IntegrationId = 102,
                                OrderStatusId = 1,
                                ReceiverAddress = "ALICI ADRESİ 102",
                                ReceiverName = "ALICI 102",
                            },
                            new Order
                            {
                                IntegrationId = 103,
                                OrderStatusId = 0,
                                ReceiverAddress = "ALICI ADRESİ 103",
                                ReceiverName = "ALICI 103",
                            },                            
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
