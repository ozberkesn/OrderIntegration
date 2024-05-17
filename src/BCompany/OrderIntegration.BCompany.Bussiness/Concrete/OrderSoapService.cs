using OrderIntegration.BCompany.Bussiness.Abstract;
using OrderIntegration.BCompany.Bussiness.Dto;

namespace OrderIntegration.BCompany.Bussiness.Concrete
{
    public class OrderSoapService : IOrderSoapService
    {
        private readonly IOrderService _orderService;
        public OrderSoapService(IOrderService orderService)
        {

            _orderService = orderService;

        }
        public async Task<List<OrderDto>> GetOrdersByDate(DateTime date)
        {
            var result =  await _orderService.GetOrdersByDate(date);
            var response = result.Select(s => new OrderDto
            {
                OrderItems = s.OrderItems.Select(a => new OrderItemDto
                {
                    ItemName = a.ItemName,
                    Quantity = a.Quantity
                }).ToList(),

            }).ToList();

            response.Add(new OrderDto
            {
                CreatedDate = DateTime.Now,
                Id= 1,
                OrderItems = new List<OrderItemDto>
                {
                    
                    new OrderItemDto
                    {
                        ItemName = "Test",
                        Quantity = 1
                    }
                }
            });

            return response;
        }
    }
}
