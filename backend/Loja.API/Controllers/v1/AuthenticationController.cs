using Loja.Domain.Interface.Service;
using Loja.Domain.Models;
using Loja.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Loja.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("loja/v{version:apiVersion}/[controller]/[Action]")]
    public class AuthenticationController:ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService=userService;
        }

        [HttpGet]
        [Obsolete]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserModel model)
        {
            var userLogado = await _userService.LoginAsync(model);

            return Ok(userLogado);
        }
        [Obsolete("Não funciona, sera desativado", true)]
        [HttpPatch]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var userLogado = await _userService.ResetPasswordAsync(model);

            return Ok(userLogado);

        }

        [Obsolete]
        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user = await _userService.UpdatePasswordAsync(model);
            return Ok(user);

        }

    }
}
