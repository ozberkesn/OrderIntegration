using AutoMapper;
using OrderIntegration.ACompany.Services.OrderManager.Application.Dtos;
using OrderIntegration.ACompany.Services.OrderManager.Domain.OrderAggregate;

namespace OrderIntegration.ACompany.Services.OrderManager.Application.Mapping
{
    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}
