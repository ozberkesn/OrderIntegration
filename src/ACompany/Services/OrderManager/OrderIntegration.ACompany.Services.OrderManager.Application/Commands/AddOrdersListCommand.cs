using MediatR;
using OrderIntegration.ACompany.Services.OrderManager.Application.Dtos;
using OrderIntegration.ACompany.Shared.Dtos;

namespace OrderIntegration.ACompany.Services.OrderManager.Application.Commands
{
    public class AddOrdersListCommand : IRequest<Response<NoContent>>
    {
        public List<OrderDto>? Orders { get; set; }
    }
}
