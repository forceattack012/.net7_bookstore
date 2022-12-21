using BookApi.Application.Commands;
using BookApi.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerRequest customerRequest) 
        {
            var result = await _mediator.Send(new CreateCustomerCommand() { customerRequest = customerRequest });
            return StatusCode(201, ((int)result));
        }
    }
}
