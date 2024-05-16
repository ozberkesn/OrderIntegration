using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderIntegration.BCompany.Entities.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public int OrderStatusId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
