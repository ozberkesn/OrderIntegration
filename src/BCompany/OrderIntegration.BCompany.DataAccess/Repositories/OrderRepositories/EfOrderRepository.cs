using OrderIntegration.BCompany.DataAccess.Context;
using OrderIntegration.BCompany.Entities.Entities;
using System.Linq.Expressions;

namespace OrderIntegration.BCompany.DataAccess.Repositories.OrderRepositories
{
    public class EfOrderRepository : EfRepositoryBase<Order>, IOrderRepository
    {
        public EfOrderRepository(BCompanyDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetOrdersByDate(DateTime date)
        {
            return await GetAllFilteredAsync(x => x.CreatedDate.Date == date.Date, x => x.OrderItems);
        }
    }
}
