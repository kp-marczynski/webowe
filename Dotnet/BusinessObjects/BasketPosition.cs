using System.ComponentModel.DataAnnotations;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class BasketPosition
    {
        public BasketPosition()
        {
            this.Event = new Event();
            this.Quantity = 0;
        }
//        
//        public BasketPosition(Event Event, int Quantity)
//        {
//            this.Event = Event;
//            this.Quantity = Quantity;
//        }

        [Required] public Event Event { get; set; }
        [Required] [Range(0, 10)] public int Quantity { get; set; }

        public int CurrentlyAvailableTickets { get; set; }
        private static int availableTickets = 10;
        [Required] public bool isChecked { get; set; } = true;

        public static BasketPosition Create(Event Event, int Quantity)
        {
            var basketPosition = new BasketPosition();
            basketPosition.Event = Event;
            basketPosition.Quantity = Quantity;
            return basketPosition;
        }
    }
}