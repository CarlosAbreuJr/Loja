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
    public class GrupoController : BaseController// ControllerBase
    {
        private readonly IGrupoService _grupoService;
        public GrupoController(IGrupoService grupoService)
        {
            _grupoService=grupoService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var grupos = await _grupoService.GetAll();
            return Ok(new ResponseBase<IEnumerable<GrupoModel>>
            {
                Data = grupos,
                Success = true
            });
        }

        [HttpPost]
        public IActionResult Add([FromBody] GrupoModel grupo )
        {
            if (!ModelState.IsValid)
                return BadRequest("Chame direito cabaço!");

            _grupoService.Add(grupo);

            return Ok("Mensagem de sucesso");
        }
    }
}