using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderIntegration.ACompany.Services.OrderManager.Application.Commands;
using OrderIntegration.ACompany.Services.OrderManager.Application.Queries;
using OrderIntegration.ACompany.Shared.ControllerBases;

namespace OrderIntegration.ACompany.Services.OrderManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : CustomBaseController
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> WaitingOrders()
        {
            var response = await _mediator.Send(new GetOrdersByStatusIdQuery { StatusId = 0 });

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> OrderDelivered(UpdateOrderCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }
    }
}
