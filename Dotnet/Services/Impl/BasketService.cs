using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.BusinessObjects;
using Shop.Repositories;

namespace Shop.Services.Impl
{
    public class BasketService : IBasketService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEventRepository _eventRepository;
        private readonly IOrderEventRepository _orderEventRepository;
        private static readonly string ItemsInCartCookieName = "items-in-cart";
        private static readonly string EventsInOrderCookieName = "order-items";

        public BasketService(IHttpContextAccessor httpContextAccessor, IEventRepository eventRepository,
            IOrderEventRepository orderEventRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _eventRepository = eventRepository;
            _orderEventRepository = orderEventRepository;
        }

        public CartCollection GetItemsInBasket()
        {
            return GetBaskedSetFromCookie(ItemsInCartCookieName);
        }

        public CartCollection GetOrderItems()
        {
            return GetBaskedSetFromCookie(EventsInOrderCookieName);
        }

        private void SaveEventsIdInCookie(CartCollection cartCollection, string cookieName)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookieName);
            var itemsInCart = JsonConvert.SerializeObject(cartCollection.GetEventsIdList());
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(30);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, itemsInCart, option);
        }

        public void SaveBasketInCookie(CartCollection cartCollection)
        {
            SaveEventsIdInCookie(cartCollection, ItemsInCartCookieName);
            SaveEventsIdInCookie(cartCollection.GetBasketWithCheckedPositions(), EventsInOrderCookieName);
        }

        public void RemoveOrderedItemsFromCookie()
        {
            var itemsJson = _httpContextAccessor.HttpContext.Request.Cookies[ItemsInCartCookieName];
            var basketJson = _httpContextAccessor.HttpContext.Request.Cookies[EventsInOrderCookieName];

            if (!string.IsNullOrEmpty(itemsJson) && !string.IsNullOrEmpty(basketJson))
            {
                List<string> itemsList = JsonConvert.DeserializeObject<List<string>>(itemsJson);
                List<string> basketList = JsonConvert.DeserializeObject<List<string>>(basketJson);
                itemsList.Sort();
                basketList.Sort();
                List<string> result = new List<string>();
                foreach (var distinctItem in itemsList.Distinct())
                {
                    for (var i = 0;
                        i < itemsList.Count(x => x == distinctItem) - basketList.Count(x => x == distinctItem);
                        ++i)
                    {
                        result.Add(distinctItem);
                    }
                }

                var itemsInCart = JsonConvert.SerializeObject(result);
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(30);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(ItemsInCartCookieName, itemsInCart, option);
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(EventsInOrderCookieName);
            }
        }

        private CartCollection GetBaskedSetFromCookie(string cookieName)
        {
            var basketSet = new CartCollection();
            var itemsJson = _httpContextAccessor.HttpContext.Request.Cookies[cookieName];
            if (!string.IsNullOrEmpty(itemsJson))
            {
                var itemsInCart = JsonConvert.DeserializeObject<List<string>>(itemsJson);

                foreach (var item in itemsInCart)
                {
                    if (int.TryParse(item, out var eventId))
                    {
                        var temp = _eventRepository.FindById(eventId);
                        if (temp != null)
                        {
                            basketSet.AddToBasket(temp);
                        }
                    }
                }
            }

            foreach (var cartPosition in basketSet.BasketPositions)
            {
                cartPosition.CurrentlyAvailableTickets = cartPosition.Event.NumberOfAvailableTickets -
                                                         _orderEventRepository.CountSoldTickets(cartPosition.Event.Id);
            }

            return basketSet;
        }
    }
}