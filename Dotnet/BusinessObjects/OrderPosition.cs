using System.ComponentModel.DataAnnotations;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class OrderPosition
    {
        public OrderPosition()
        {
            this.Event = new Event();
            this.Quantity = 0;
        }
//        
//        public OrderPosition(Event Event, int Quantity)
//        {
//            this.Event = Event;
//            this.Quantity = Quantity;
//        }

        [Required] public Event Event { get; set; }
        [Required] public int Quantity { get; set; }

        public int CurrentlyAvailableTickets { get; set; }
//        private static int availableTickets = 10;
        [Required] public bool isChecked { get; set; } = true;

        public static OrderPosition Create(Event Event, int Quantity)
        {
            var basketPosition = new OrderPosition();
            basketPosition.Event = Event;
            basketPosition.Quantity = Quantity;
            return basketPosition;
        }
    }
}