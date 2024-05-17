using OrderIntegration.ACompany.Services.OrderManager.DomainCore;

namespace OrderIntegration.ACompany.Services.OrderManager.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public OrderItem()
        {
        }
        public OrderItem(string itemName, int quantity)
        {
            ItemName = itemName;
            Quantity = quantity;
        }
    }
}
