using Sklep.Entities;

namespace Sklep.BusinessObjects
{
    public class BasketPosition
    {
        public BasketPosition(Event Event, int Quantity)
        {
            this.Event = Event;
            this.Quantity = Quantity;
        }
        
        public Event Event { get;}
        public int Quantity { get; set; }
    }
}