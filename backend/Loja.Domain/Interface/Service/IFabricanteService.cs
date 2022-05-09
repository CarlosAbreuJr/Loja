
using Loja.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.Service
{
    public interface IFabricanteService
    {
        Task<IEnumerable<FabricanteModel>> GetAllAsync();
        void Add(FabricanteModel model);   

    }
}
