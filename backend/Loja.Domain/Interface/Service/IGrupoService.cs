
using Loja.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.Service
{
    public interface IGrupoService
    {
        Task<IEnumerable<GrupoModel>> GetAll();
        void Add(GrupoModel model);   

    }
}
