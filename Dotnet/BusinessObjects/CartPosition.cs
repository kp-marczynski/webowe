using System.ComponentModel.DataAnnotations;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class CartPosition
    {
        public CartPosition()
        {
            Event = new Event();
            Quantity = 0;
        }


        [Required] public Event Event { get; set; }
        [Required] public int Quantity { get; set; }

        public int CurrentlyAvailableTickets { get; set; }

        [Required] public bool IsChecked { get; set; } = true;

        public static CartPosition Create(Event ev, int quantity)
        {
            var basketPosition = new CartPosition {Event = ev, Quantity = quantity};
            return basketPosition;
        }
    }
}