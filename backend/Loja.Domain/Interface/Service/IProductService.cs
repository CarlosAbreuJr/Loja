
using Loja.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAll();
        void Add(ProductModel model);   

    }
}
