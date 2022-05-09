using Loja.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.Service
{
    public interface IClientService
    {
        Task<IEnumerable<ClientModel>> GetAllAsync();
        void Add(ClientModel model);

    }
}
