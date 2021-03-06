using Loja.Domain.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Infra.Data.Extension
{
    public static class IQueryableExtension
    {
        public static async Task<IPagedList<TEntity>> ToPagedListAsync<TEntity>(this IQueryable<TEntity> query, int pageNumber, int pageSize) where TEntity : class
        {
            var totalItemCount = query.Count();
            var items = await query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToArrayAsync();
            return new PagedList<TEntity>(pageNumber, pageSize, totalItemCount, items);
        }
    }
}
