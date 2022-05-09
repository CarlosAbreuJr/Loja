using AutoMapper;
using Loja.Domain.Entities;
using Loja.Domain.Interface.Repositories;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;

namespace Loja.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository=productRepository;
            _mapper=mapper;
        }

        public async void Add(ProductModel model)
        {
            var product = _mapper.Map<Product>(model); 
            await _productRepository.AddAsync(product);
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            var product = await _productRepository.GetAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(product);
            

        }
    }
}