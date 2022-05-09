using AutoMapper;
using Loja.API.Controllers.Shared;
using Loja.API.Resources;
using Loja.Domain.Entities;
using Loja.Domain.Enuns;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;
using Loja.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Loja.API.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("loja/v{version:apiVersion}/[controller]/[Action]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService=userService;
        }

        [Obsolete]
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserModel userCredentials)//UserCredentialsResource userCredentials)
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

        [HttpPatch]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var userLogado = await _userService.ResetPasswordAsync(model);

            return Ok(userLogado);

        }


        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user = await _userService.UpdatePasswordAsync(model);
            return Ok(user);

        }


    }
}