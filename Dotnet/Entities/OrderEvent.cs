using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.BusinessObjects;

namespace Shop.Entities
{
    [Table("orders_events")]
    public class OrderEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Column("order_id")] public int OrderId { get; set; }
        [Required, Column("event_id")] public int EventId { get; set; }
        [Required] [Column("event_name")] public string EventName { get; set; }
        [Required] [Column("event_price")] public double EventPrice { get; set; }
        [Required] [Column("event_place")] public string EventPlace { get; set; }
        //todo event date
        [Required] [Column("quantity")] public int Quantity { get; set; }


        public static OrderEvent createOrderEvent(Event ev, int quantity, int orderId)
        {
            return new OrderEvent
            {
                OrderId = orderId,
                EventId = ev.Id,
                EventName = ev.Name,
                EventPlace = ev.Place,
                EventPrice = ev.Price,
                Quantity = quantity
            };
        }

        public static List<OrderEvent> createOrderEventList(CompleteOrder completeOrder)
        {
            if (completeOrder.OrderId == null)
                return null;
            var result = new List<OrderEvent>();
            foreach (var basketPosition in completeOrder.Events.BasketPositions)
            {
                result.Add(createOrderEvent(basketPosition.Event,basketPosition.Quantity,(int) completeOrder.OrderId));
            }

            return result;
        }
    }
}