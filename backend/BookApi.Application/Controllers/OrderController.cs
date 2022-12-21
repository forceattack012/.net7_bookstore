using BookApi.Application.Commands;
using BookApi.Application.DTOs;
using BookApi.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderRequest orderRequest)
        {
            var result = await _mediator.Send(new CreateOrderCommand() { Order = orderRequest });
            return StatusCode(201, (result));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrdersByUserId(string userId)
        {
            var result = await _mediator.Send(new GetOrdersByUserIdQuery() { UserId = userId });
            return Ok(result);
        }
    }
}
