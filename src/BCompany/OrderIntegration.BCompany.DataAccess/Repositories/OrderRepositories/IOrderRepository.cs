using Microsoft.EntityFrameworkCore;
using OrderIntegration.BCompany.Entities.Entities;
using System.Linq.Expressions;

namespace OrderIntegration.BCompany.DataAccess.Repositories.OrderRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<List<Order>> GetOrdersByDate(DateTime date);
    }
}
