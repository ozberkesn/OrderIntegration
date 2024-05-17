namespace OrderIntegration.ACompany.Web.Models.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}
