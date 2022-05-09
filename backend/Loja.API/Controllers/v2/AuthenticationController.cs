using AutoMapper;
using Loja.API.Resources;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;
using Loja.Domain.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Loja.API.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("loja/v{version:apiVersion}/[controller]/[Action]")]

    public class AuthenticationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService=authenticationService;
            _mapper=mapper;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentialsResource userCredentials)
        {
            Thread.Sleep(10000);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _authenticationService.CreateAccessTokenAsync(userCredentials.Email, userCredentials.Password);

                //var accessTokenResource = _mapper.Map<AccessTokenResource>(response);
                return Ok(response);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenResource refreshTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _authenticationService.RefreshTokenAsync(refreshTokenResource.Token, refreshTokenResource.UserEmail);
                var accessTokenResource = _mapper.Map<AccessTokenResource>(response);
                return Ok(accessTokenResource);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        [HttpPost]
        public IActionResult RevokeToken([FromBody] RevokeTokenResource revokeTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _authenticationService.RevokeRefreshToken(revokeTokenResource.Token);
            return NoContent();
        }
    }
}
