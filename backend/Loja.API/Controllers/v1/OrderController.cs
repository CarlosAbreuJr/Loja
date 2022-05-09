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
    public class OrderController : BaseController// ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService=orderService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(new ResponseBase<IEnumerable<OrderModel>>
            {
                Data = orders,
                Success = true
            });
        }

        [HttpPost]
        public IActionResult Add([FromBody] OrderModel order )
        {
            _orderService.Add(order);

            return Ok("Mensagem de sucesso");
        }
    }
}