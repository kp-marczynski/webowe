using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.BusinessObjects;
using Shop.BusinessObjects.Enums;
using Shop.Entities;

namespace Shop.Services.Impl
{
    public class OrderService : IOrderService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private string orderStateKey = "order-state";
        private string shipmentInfoKey = "shipment-info";

        private IBasketService _basketService;
        private IUserService _userService;
        private ShopDbContext _shopDbContext;

        public OrderService(IHttpContextAccessor httpContextAccessor, IBasketService basketService,
            IUserService userService, ShopDbContext shopDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _basketService = basketService;
            _userService = userService;
            _shopDbContext = shopDbContext;
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

        public CompleteOrder GetCurrentCompleteOrder()
        {
            var shipmentInfo = GetShipmentInfoFromSession();
            var basket = _basketService.GetItemsInBasket();
            var currentUser = _userService.GetCurrentUser();
            return new CompleteOrder(currentUser, shipmentInfo, basket);
        }

        public CompleteOrder SaveCurrentOrderInDb()
        {
            var currentOrder = GetCurrentCompleteOrder();
            var baseOrder = BaseOrder.createBaseOrder(currentOrder);
//            Console.WriteLine(currentOrder);
//            var orderEventList = currentOrder.getOrderEventList();
            _shopDbContext.baseOrders.Add(baseOrder);
            _shopDbContext.SaveChanges();

            currentOrder.orderId = baseOrder.Id;

            var orderEventList = OrderEvent.createOrderEventList(currentOrder);
            _shopDbContext.OrderEvents.AddRange(orderEventList);
            _shopDbContext.SaveChanges();
            if (verifyOrder(orderEventList))
            {
                baseOrder.OrderStatus = OrderProcessingState.Verified.ToString();
            }
            else
            {
                baseOrder.OrderStatus = OrderProcessingState.VerificationFailed.ToString();
            }

            _shopDbContext.Update(baseOrder);
            _shopDbContext.SaveChanges();

            return currentOrder;
        }

        public List<OrderPosition> getCurrentUserOrders()
        {
            var result = new List<OrderPosition>();
            var currentUser = _userService.GetCurrentUser();
            var baseOrders = _shopDbContext.baseOrders.Where(x => x.UserId == currentUser.Id).ToList();
            foreach (var baseOrder in baseOrders)
            {
                var events = _shopDbContext.OrderEvents.Where(x => x.OrderId == baseOrder.Id).ToList();
                result.Add(new OrderPosition(baseOrder, events));
            }

            return result;
        }

        private bool verifyOrder(List<OrderEvent> orderEvents)
        {
            foreach (var orderEvent in orderEvents)
            {
                var eventId = orderEvent.EventId;
                var ev = _shopDbContext.events.Find(eventId);
                if (ev == null) return false;

                List<int> wrongOrdersIds = _shopDbContext.baseOrders.Where(z =>
                        z.OrderStatus == OrderProcessingState.NotVerified.ToString()
                        || z.OrderStatus == OrderProcessingState.VerificationFailed.ToString())
                    .ToList().Select(x => x.Id).ToList();
//                Console.WriteLine("Wrong orderIds: ");
//                foreach (var wrongOrdersId in wrongOrdersIds)
//                {
//                    Console.WriteLine(wrongOrdersId);
//                }
//
//                Console.WriteLine("Available tickets: " + ev.NumberOfAvailableTickets);
                var soldTickets = _shopDbContext.OrderEvents.Where(x =>
                    x.EventId == eventId &&
                    !wrongOrdersIds.Contains(x.OrderId)
                ).Sum(y => y.Quantity);
//                Console.WriteLine("Sold tickets: " + soldTickets);

                if (soldTickets + orderEvent.Quantity > ev.NumberOfAvailableTickets) return false;
            }

            return true;
        }
    }
}