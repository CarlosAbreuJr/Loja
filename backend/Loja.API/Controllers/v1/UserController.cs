using Loja.API.Controllers.Shared;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Loja.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService=userService;
        }

        [Obsolete]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserModel model)
        {
            _userService.Add(model);
            return Created("", model);
        }

    }
}