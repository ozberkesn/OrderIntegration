namespace OrderIntegration.ACompany.Services.OrderManager.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public DateTime CreatedDate { get;  set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
