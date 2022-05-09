using Loja.API.Controllers.Shared;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Loja.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    //^^^^^^^^^^ se deixar mais de uma versão na controller os métodos vão apareceer em todas as versões,
    //a menos que coloque MapToApiVersion("2.0"), o método mapeado só irá aparecer a versão especificada
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService=clientService;
        }

        //[HttpGet, Route("consultaX/version")]
        //public string Get() => "Version 1";
        //[HttpGet, Route("consultaY/version"), MapToApiVersion("2.0")]
        //public string GetV2() => "Version 2";

        [HttpGet]
        public async Task<IActionResult> GetClient()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientModel model)
        {
            _clientService.Add(model);
            return Created("", model);
        }

    }
}
