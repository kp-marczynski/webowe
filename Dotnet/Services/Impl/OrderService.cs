using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.BusinessObjects;
using Shop.BusinessObjects.Enums;
using Shop.Entities;
using Shop.Repositories;

namespace Shop.Services.Impl
{
    public class OrderService : IOrderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;
        private readonly IEventRepository _eventRepository;
        private readonly IBaseOrderRepository _baseOrderRepository;
        private readonly IOrderEventRepository _orderEventRepository;

        private string orderStateKey = "order-state";
        private string shipmentInfoKey = "shipment-info";

        public OrderService(IHttpContextAccessor httpContextAccessor, IBasketService basketService,
            IUserService userService, IEventRepository eventRepository, IBaseOrderRepository baseOrderRepository,
            IOrderEventRepository orderEventRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _basketService = basketService;
            _userService = userService;
            _eventRepository = eventRepository;
            _baseOrderRepository = baseOrderRepository;
            _orderEventRepository = orderEventRepository;
        }

//        public OrderState? CurrentOrderState()
//        {
//            if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString(orderStateKey)))
//                return (OrderState) Enum.Parse(typeof(OrderState),
//                    _httpContextAccessor.HttpContext.Session.GetString(orderStateKey));
//            return null;
//        }
//
//        public void SetCurrentOrderState(OrderState state)
//        {
//            _httpContextAccessor.HttpContext.Session.SetString(orderStateKey, state.ToString());
//        }

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

        public CompleteOrder SaveCurrentOrderInDb()
        {
            var currentOrder = GetCurrentCompleteOrder();
            var baseOrder = BaseOrder.CreateBaseOrder(currentOrder);

            baseOrder = _baseOrderRepository.SaveAndFlush(baseOrder);

            currentOrder.OrderId = baseOrder.Id;

            var orderEventList = OrderEvent.createOrderEventList(currentOrder);
            _orderEventRepository.SaveAll(orderEventList);
            if (VerifyOrder(orderEventList))
            {
                baseOrder.OrderStatus = OrderProcessingStatus.Verified.ToString();
            }
            else
            {
                baseOrder.OrderStatus = OrderProcessingStatus.VerificationFailed.ToString();
            }

            baseOrder = _baseOrderRepository.Update(baseOrder);

            return currentOrder;
        }

        public List<OrderPosition> getCurrentUserOrders()
        {
            var result = new List<OrderPosition>();
            var currentUser = _userService.GetCurrentUser();
            var baseOrders = _baseOrderRepository.FindAllByUserId(currentUser.Id);
            foreach (var baseOrder in baseOrders)
            {
                var events = _orderEventRepository.FindByOrderId(baseOrder.Id);
                result.Add(new OrderPosition(baseOrder, events));
            }

            return result;
        }

        private bool VerifyOrder(List<OrderEvent> orderEvents)
        {
            foreach (var orderEvent in orderEvents)
            {
                var eventId = orderEvent.EventId;
                var ev = _eventRepository.FindById(eventId);
                if (ev == null) return false;

                var soldTickets = _orderEventRepository.CountSoldTickets(eventId);
                if (soldTickets + orderEvent.Quantity > ev.NumberOfAvailableTickets) return false;
            }

            return true;
        }

        private CompleteOrder GetCurrentCompleteOrder()
        {
            var shipmentInfo = GetShipmentInfoFromSession();
            var basket = _basketService.GetItemsInBasket();
            var currentUser = _userService.GetCurrentUser();
            return new CompleteOrder(currentUser, shipmentInfo, basket);
        }
    }
}