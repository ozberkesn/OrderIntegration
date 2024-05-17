using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderIntegration.ACompany.Services.OrderManager.Application.Commands;
using OrderIntegration.ACompany.Services.OrderManager.Application.Mapping;
using OrderIntegration.ACompany.Services.OrderManager.Domain.OrderAggregate;
using OrderIntegration.ACompany.Services.OrderManager.Infrastructure;
using OrderIntegration.ACompany.Shared.Dtos;
using System.Net;

namespace OrderIntegration.ACompany.Services.OrderManager.Application.Handlers
{
    public class AddOrdersListCommandHandler : IRequestHandler<AddOrdersListCommand, Response<NoContent>>
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public AddOrdersListCommandHandler(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<Response<NoContent>> Handle(AddOrdersListCommand request, CancellationToken cancellationToken)
        {;
            using (var scope = _scopeFactory.CreateScope()) 
            {
                var _context = scope.ServiceProvider.GetRequiredService<OrderDBContext>(); 
                var newOrders = ObjectMapper.Mapper.Map<List<Order>>(request.Orders);
                await _context.Orders.AddRangeAsync(newOrders);
                await _context.SaveChangesAsync();
                return Response<NoContent>.Success((int)HttpStatusCode.Created);

            }
           
        }
    }
}
