using System.Collections.Generic;

namespace Loja.Domain.Models.Shared
{
    public interface IPagedList<TEntity> where TEntity : class
    {
        int PageNumber { get; }
        int PageSize { get; }
        int TotalItemCount { get; }

        IEnumerable<TEntity> Items { get; }
    }
}
