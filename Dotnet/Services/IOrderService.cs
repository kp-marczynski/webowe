using System.Collections.Generic;
using Shop.BusinessObjects;
using Shop.BusinessObjects.Enums;

namespace Shop.Services
{
    public interface IOrderService
    {
//        OrderState? CurrentOrderState();
//        void SetCurrentOrderState(OrderState state);

        void SaveShipmentInfoInSession(ShipmentInfo shipmentInfo);
        ShipmentInfo GetShipmentInfoFromSession();
//        CompleteOrder GetCurrentCompleteOrder();

        CompleteOrder SaveCurrentOrderInDb(CartCollection cartCollection, ShipmentInfo shipmentInfo);
        List<OrderPosition> getCurrentUserOrders();
    }
}