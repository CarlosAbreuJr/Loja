using Microsoft.AspNetCore.Mvc;
using Loja.API.Controllers.Shared;

namespace Loja.API.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("loja/v{version:apiVersion}/[controller]/[Action]")]
    public class ProductController : BaseController// ControllerBase
    {
        public ProductController()
        {
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Mensagem de sucesso da Api V2");
        }
    }
}