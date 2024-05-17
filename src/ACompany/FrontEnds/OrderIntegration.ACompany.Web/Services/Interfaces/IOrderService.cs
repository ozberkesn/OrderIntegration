using OrderIntegration.ACompany.Web.Models.Orders;

namespace OrderIntegration.ACompany.Web.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetWaitingOrders();
        Task<OrderUpdatedViewModel> UpdateOrderStatus(UpdateOrderInput updateOrderInput);
    }
}
