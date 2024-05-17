using OrderIntegration.ACompany.Services.OrderManager.DomainCore;

namespace OrderIntegration.ACompany.Services.OrderManager.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public int IntegrationId { get; set; }
        public int CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public DateTime CreatedDate { get; private set; }
        private readonly List<OrderItem> _orderItems;

        public ICollection<OrderItem> OrderItems => _orderItems;
        public Order()
        {
            CreatedDate = DateTime.Now;
        }
        public Order(int customerId)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            CustomerId = customerId;
        }

        public decimal GetTotalQuantity => _orderItems.Sum(x => x.Quantity);
    }
}
