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
                CreatedDate = date,
                Id = s.Id,
                OrderItems = s.OrderItems.Select(a => new OrderItemDto
                {
                    ItemName = a.ItemName,
                    Quantity = a.Quantity
                }).ToList(),

            }).ToList();
            return response;
        }
    }
}
