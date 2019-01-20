using Shop.BusinessObjects;

namespace Shop.Services
{
    public interface IOrderService
    {
        OrderState? CurrentOrderState();
        void SetCurrentOrderState(OrderState state);

        void SaveShipmentInfoInSession(ShipmentInfo shipmentInfo);
        ShipmentInfo GetShipmentInfoFromSession();
    }
}