using System;
using System.Collections.Generic;
using Shop.BusinessObjects.Enums;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class CompleteOrder
    {
        public int? orderId { get; set; }
        public User user { get; set; }
        public ShipmentInfo shipmentInfo { get; set; }
        public OrderCollection events { get; set; }
        public OrderProcessingState OrderProcessingState { get; set; }
        public DateTime? OrderDate { get; set; }

        public CompleteOrder(User user, ShipmentInfo shipmentInfo, OrderCollection orderCollection)
        {
            this.orderId = null;
            this.user = user;
            this.shipmentInfo = shipmentInfo;
            this.events = orderCollection;
            this.OrderProcessingState = OrderProcessingState.NotVerified;
        }

//        public BaseOrder getBaseOrder()
//        {
//            return BaseOrder.createBaseOrder(this);
//        }

//        public List<OrderEvent> getOrderEventList()
//        {
//            return new List<OrderEvent>();
//        }
    }
}