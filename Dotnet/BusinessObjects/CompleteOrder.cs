using Sklep.Entities;

namespace Sklep.BusinessObjects
{
    public class CompleteOrder
    {
        public int orderId { get; set; }
        public User user { get; set; }
        public ShipmentInfo shipmentInfo { get; set; }
        public BasketSet events { get; set; }

        public static void saveCompleteOrder()
        {
            
        }
    }
}