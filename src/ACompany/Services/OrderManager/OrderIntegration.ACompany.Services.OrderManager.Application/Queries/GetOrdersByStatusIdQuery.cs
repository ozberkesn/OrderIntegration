using MediatR;
using OrderIntegration.ACompany.Services.OrderManager.Application.Dtos;
using OrderIntegration.ACompany.Shared.Dtos;

namespace OrderIntegration.ACompany.Services.OrderManager.Application.Queries
{
    public class GetOrdersByStatusIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public int StatusId { get; set; }
    }
}
