using OrderIntegration.BCompany.Bussiness.Abstract;
using OrderIntegration.BCompany.DataAccess.Repositories.OrderRepositories;
using OrderIntegration.BCompany.Entities.Entities;

namespace OrderIntegration.BCompany.Bussiness.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetOrdersByDate(DateTime date)
        {
            return await _orderRepository.GetOrdersByDate(date);
        }
    }
}
