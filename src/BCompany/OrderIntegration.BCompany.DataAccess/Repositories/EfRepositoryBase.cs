using Microsoft.EntityFrameworkCore;
using OrderIntegration.BCompany.DataAccess.Context;
using System.Linq.Expressions;

namespace OrderIntegration.BCompany.DataAccess.Repositories
{
    public class EfRepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly BCompanyDbContext _context;

        public EfRepositoryBase(BCompanyDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllFilteredAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(filter).ToListAsync();
        }
    }
}
