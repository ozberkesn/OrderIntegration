using OrderIntegration.BCompany.Entities.Entities;

namespace OrderIntegration.BCompany.Bussiness.Abstract
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersByDate();
    }
}
