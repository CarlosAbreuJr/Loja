using Loja.API.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers.Shared
{
    [ApiController]
    [Route("loja/v{version:apiVersion}/[controller]")]
    //[Route("loja/v{version:apiVersion}/[controller]"), CustomAuthorize(Policy = "Authenticated")]
    public class BaseController : ControllerBase
    {
    }
}
