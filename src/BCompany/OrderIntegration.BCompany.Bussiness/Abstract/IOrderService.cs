using OrderIntegration.BCompany.Entities.Entities;
using System.ServiceModel;

namespace OrderIntegration.BCompany.Bussiness.Abstract
{   
    public interface IOrderService
    {     
        Task<List<Order>> GetOrdersByDate(DateTime date);
    }
}
