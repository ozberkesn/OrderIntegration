using System.Linq.Expressions;

namespace OrderIntegration.BCompany.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllFilteredAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

    }
}
