using MediatR;
using OrderIntegration.ACompany.Services.OrderManager.Application.Dtos;
using OrderIntegration.ACompany.Shared.Dtos;

namespace OrderIntegration.ACompany.Services.OrderManager.Application.Commands
{
    public class UpdateOrderCommand : IRequest<Response<UpdatedOrderDto>>
    {
        public int StatusId { get; set; }
        public int OrderId { get; set; }
    }
}
