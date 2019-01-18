using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Entities
{
    [Table("orders_events")]
    public class OrderEvent
    {
        public int OrderId { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public float EventPrice { get; set; }
        public string EventPlace { get; set; }
        public int Quantity { get; set; }
    }
}