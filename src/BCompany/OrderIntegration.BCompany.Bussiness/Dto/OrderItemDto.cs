using System.Runtime.Serialization;

namespace OrderIntegration.BCompany.Bussiness.Dto
{
    [DataContract]
    public class OrderItemDto
    {
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
