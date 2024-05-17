using System.Runtime.Serialization;

namespace OrderIntegration.BCompany.Bussiness.Dto
{
    [DataContract]
    public class OrderDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
