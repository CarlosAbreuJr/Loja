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
    public class FabricanteController : BaseController// ControllerBase
    {
        private readonly IFabricanteService _fabricanteService;
        public FabricanteController(IFabricanteService fabricanteService)
        {
            _fabricanteService=fabricanteService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fabricantes = await _fabricanteService.GetAllAsync();
            return Ok(new ResponseBase<IEnumerable<FabricanteModel>>
                    {
                        Data = fabricantes,
                        Success = true
                    });
        }

        [HttpPost]
        public IActionResult Add([FromBody] FabricanteModel fabricante )
        {
            _fabricanteService.Add(fabricante);

            return Ok("Mensagem de sucesso");
        }
    }
}