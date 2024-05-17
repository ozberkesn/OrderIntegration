using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderIntegration.ACompany.Services.OrderManager.Application.Commands;
using OrderIntegration.ACompany.Services.OrderManager.Application.Dtos;
using OrderIntegration.ACompany.Services.OrderManager.Infrastructure;
using OrderIntegration.ACompany.Shared.Dtos;
using System.Net;

namespace OrderIntegration.ACompany.Services.OrderManager.Application.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Response<UpdatedOrderDto>>
    {
        private readonly OrderDBContext _context;
        public UpdateOrderCommandHandler(OrderDBContext context)
        {
            _context = context;
        }

        public async Task<Response<UpdatedOrderDto>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderId);
            if (order != null)
            {
                order.OrderStatusId = request.StatusId;
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
                return Response<UpdatedOrderDto>.Success(new UpdatedOrderDto { Id = order.Id }, (int)HttpStatusCode.OK);
            }

            return Response<UpdatedOrderDto>.Fail(new List<string> { "" }, (int)HttpStatusCode.NoContent);

        }
    }
}
