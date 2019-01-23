using System;
using Shop.BusinessObjects.Enums;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class CompleteOrder
    {
        public int? OrderId { get; set; }
        public User User { get; set; }
        public ShipmentInfo ShipmentInfo { get; set; }
        public CartCollection Events { get; set; }
        public OrderProcessingStatus OrderProcessingStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public double ShippingCost { get; set; } = 15.5;
        public double TotalPrice()
        {
            var result = ShippingCost;
            foreach (var ev in Events.BasketPositions)
            {
                result += ev.Quantity * ev.Event.Price;
            }

            return result;
        } 

        public CompleteOrder(User user, ShipmentInfo shipmentInfo, CartCollection cartCollection)
        {
            OrderId = null;
            User = user;
            ShipmentInfo = shipmentInfo;
            Events = cartCollection;
            OrderProcessingStatus = OrderProcessingStatus.NotVerified;
            OrderDate = cartCollection.CurrentTime;
        }
    }
}