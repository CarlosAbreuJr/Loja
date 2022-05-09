using System;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
