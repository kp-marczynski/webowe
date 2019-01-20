using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.BusinessObjects;

namespace Shop.Services.Impl
{
    public class OrderService : IOrderService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private string orderStateKey = "order-state";
        private string shipmentInfoKey = "shipment-info";

        public OrderService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public OrderState? CurrentOrderState()
        {
            if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString(orderStateKey)))
                return (OrderState) Enum.Parse(typeof(OrderState),
                    _httpContextAccessor.HttpContext.Session.GetString(orderStateKey));
            return null;
        }

        public void SetCurrentOrderState(OrderState state)
        {
            _httpContextAccessor.HttpContext.Session.SetString(orderStateKey, state.ToString());
        }

        public void SaveShipmentInfoInSession(ShipmentInfo shipmentInfo)
        {
            _httpContextAccessor.HttpContext.Session.SetString(shipmentInfoKey,
                JsonConvert.SerializeObject(shipmentInfo));
        }

        public ShipmentInfo GetShipmentInfoFromSession()
        {
            if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString(shipmentInfoKey)))
                return JsonConvert.DeserializeObject<ShipmentInfo>(
                    _httpContextAccessor.HttpContext.Session.GetString(shipmentInfoKey));
            return null;
        }
    }
}