using AutoMapper;
using Loja.API.Controllers.Shared;
using Loja.API.Filter;
using Loja.API.Resources;
using Loja.Domain.Entities;
using Loja.Domain.Enuns;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Loja.API.Controllers.v3
{
    [ApiVersion("3.0")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService=userService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserNoPassModel userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.CreateUserAsync(userCredentials, ApplicationRole.Common);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAsync(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string nome = User.Identity.Name;

            var user = await _userService.GetByEmailAsync(email);

            if (user == null)
                return BadRequest("Usuário não encontrado!!!");
            return Ok(user);
        }

    }
}