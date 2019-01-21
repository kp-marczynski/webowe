using System.ComponentModel.DataAnnotations;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class CartPosition
    {
        public CartPosition()
        {
            this.Event = new Event();
            this.Quantity = 0;
        }
//        
//        public CartPosition(Event Event, int Quantity)
//        {
//            this.Event = Event;
//            this.Quantity = Quantity;
//        }

        [Required] public Event Event { get; set; }
        [Required] public int Quantity { get; set; }

        public int CurrentlyAvailableTickets { get; set; }
//        private static int availableTickets = 10;
        [Required] public bool isChecked { get; set; } = true;

        public static CartPosition Create(Event Event, int Quantity)
        {
            var basketPosition = new CartPosition();
            basketPosition.Event = Event;
            basketPosition.Quantity = Quantity;
            return basketPosition;
        }
    }
}