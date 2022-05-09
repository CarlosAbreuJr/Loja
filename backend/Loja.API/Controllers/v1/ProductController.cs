using Microsoft.AspNetCore.Mvc;
using Loja.API.Controllers.Shared;
using Loja.Domain.Models;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseController// ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService=productService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAll();
            return Ok(new ResponseBase<IEnumerable<ProductModel>>
            {
                Data = products,
                Success = true
            });
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductModel product )
        {
            _productService.Add(product);

            return Ok("Mensagem de sucesso");
        }
    }
}