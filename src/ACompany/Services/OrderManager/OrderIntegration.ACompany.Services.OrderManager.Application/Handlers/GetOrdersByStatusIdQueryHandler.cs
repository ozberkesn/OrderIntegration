using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderIntegration.ACompany.Services.OrderManager.Application.Dtos;
using OrderIntegration.ACompany.Services.OrderManager.Application.Mapping;
using OrderIntegration.ACompany.Services.OrderManager.Application.Queries;
using OrderIntegration.ACompany.Services.OrderManager.Infrastructure;
using OrderIntegration.ACompany.Shared.Dtos;
using System.Net;

namespace OrderIntegration.ACompany.Services.OrderManager.Application.Handlers
{
    internal class GetOrdersByStatusIdQueryHandler : IRequestHandler<GetOrdersByStatusIdQuery, Response<List<OrderDto>>>
    {
        private readonly OrderDBContext _context;
        public GetOrdersByStatusIdQueryHandler(OrderDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<OrderDto>>> Handle(GetOrdersByStatusIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).Where(x => x.OrderStatusId == request.StatusId).ToListAsync();

            if (!orders.Any())
            {
                return Response<List<OrderDto>>.Success(new List<OrderDto>(), (int)HttpStatusCode.OK);
            }

            var ordersDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);

            return Response<List<OrderDto>>.Success(ordersDto, (int)HttpStatusCode.OK);
        }

    }
}
