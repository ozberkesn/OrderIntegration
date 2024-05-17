using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderIntegration.BCompany.DataAccess.Context;
using OrderIntegration.BCompany.Entities.Entities;

namespace OrderIntegration.BCompany.DataAccess
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<BCompanyDbContext>();
                context.Database.Migrate();

                if (!context.Orders.Any())
                {
                    context.AddRange(new List<Order>
                        {
                            new Order
                            {
                                CreatedDate = DateTime.Now,
                                OrderStatusId = 0,
                                ReceiverAddress = "ALICI ADRESİ 1",
                                ReceiverName = "ALICI 1",
                                OrderItems = new List<OrderItem>
                                {
                                    new OrderItem
                                    {
                                        ItemName = "ITEM1",
                                        Quantity = 1,
                                    }
                                }
                            },
                            new Order
                            {
                                CreatedDate = DateTime.Now.AddDays(-1),
                                OrderStatusId = 0,
                                ReceiverAddress = "ALICI ADRESİ 2",
                                ReceiverName = "ALICI 2",
                                OrderItems = new List<OrderItem>
                                {
                                    new OrderItem
                                    {
                                        ItemName = "ITEM2",
                                        Quantity = 2,
                                    }
                                }
                            },
                            new Order
                            {
                                CreatedDate = DateTime.Now.AddDays(-2),
                                OrderStatusId = 0,
                                ReceiverAddress = "ALICI ADRESİ 3",
                                ReceiverName = "ALICI 3",
                                OrderItems = new List<OrderItem>
                                {
                                    new OrderItem
                                    {
                                        ItemName = "ITEM1",
                                        Quantity = 3,
                                    }
                                }
                            },
                            new Order
                            {
                                CreatedDate = DateTime.Now.AddDays(-3),
                                OrderStatusId = 0,
                                ReceiverAddress = "ALICI ADRESİ 4",
                                ReceiverName = "ALICI 4",
                                OrderItems = new List<OrderItem>
                                {
                                    new OrderItem
                                    {
                                        ItemName = "ITEM2",
                                        Quantity = 4,
                                    }
                                }
                            },
                            new Order
                            {
                                CreatedDate = DateTime.Now.AddDays(-4),
                                OrderStatusId = 0,
                                ReceiverAddress = "ALICI ADRESİ 5",
                                ReceiverName = "ALICI 5",
                                OrderItems = new List<OrderItem>
                                {
                                    new OrderItem
                                    {
                                        ItemName = "ITEM1",
                                        Quantity = 5,
                                    }
                                }
                            }
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
