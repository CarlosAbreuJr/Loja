using Loja.Domain.Interface.Repositories;
using System.Threading.Tasks;

namespace Loja.Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LojaDbContext _context;

        public UnitOfWork(LojaDbContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
