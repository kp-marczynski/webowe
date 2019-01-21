using System.Collections.Generic;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class OrderPosition
    {
        public BaseOrder BaseOrder { get; set; }
        public List<OrderEvent> OrderEvents { get; set; }

        public OrderPosition(BaseOrder baseOrder, List<OrderEvent> orderEvents)
        {
            BaseOrder = baseOrder;
            OrderEvents = orderEvents;
        }
    }
}