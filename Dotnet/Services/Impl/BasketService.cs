using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.BusinessObjects;
using System.Linq;
using Shop.Entities;

namespace Shop.Services.Impl
{
    public class BasketService : IBasketService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ShopDbContext _shopDbContext;
        private static readonly string ItemsCookieName = "items-in-cart";
        private static readonly string BasketCookieName = "basket-items";

        public BasketService(IHttpContextAccessor httpContextAccessor, ShopDbContext shopDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _shopDbContext = shopDbContext;
        }

        public BasketSet GetItemsInBasket()
        {
            var basketSet = new BasketSet();
            var itemsJson = _httpContextAccessor.HttpContext.Request.Cookies[ItemsCookieName];
            if (!string.IsNullOrEmpty(itemsJson))
            {
                var itemsInCart = JsonConvert.DeserializeObject<List<string>>(itemsJson);

                foreach (var item in itemsInCart)
                {
                    var temp = _shopDbContext.events.Where(x => x.Id.ToString() == item).ToList();
//                    var first = _dbContext.events.Where(x => x.Id == 1).OrderByDescending(x => x.AdditionalInfo).First();
                    if (temp.Count == 1)
                    {
                        basketSet.addToBasket(temp[0]);
                    }
                }
            }

//            foreach (var basketPosition in basketSet.BasketPositions)
//            {
//                //get currently available tickets from event.availableTicksts - Count(orderId)
//            }

//            for (int i = 0; i < basketSet.b; i++)
//            {
//                
//            }
            return basketSet;
        }


        private void SaveEventsIdInCookie(BasketSet basketSet)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(ItemsCookieName);
            var itemsInCart = JsonConvert.SerializeObject(basketSet.GetEventsIdList());
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMilliseconds(60 * 60 * 24 * 30);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(ItemsCookieName, itemsInCart, option);
        }

        public void SaveBasketInCookie(BasketSet basketSet)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(BasketCookieName);
            var itemsInCart = JsonConvert.SerializeObject(basketSet.GetBasketWithCheckedPositions());
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddHours(1);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(BasketCookieName, itemsInCart, option);
        }

        public void RemoveOrderedItemsFromCookie()
        {
            var oldBasket = GetItemsInBasket();

            var basketJson = _httpContextAccessor.HttpContext.Request.Cookies[BasketCookieName];
            BasketSet ordered = new BasketSet();
            if (!string.IsNullOrEmpty(basketJson))
            {
                ordered = JsonConvert.DeserializeObject<BasketSet>(basketJson);
            }

            if (oldBasket != null && ordered != null)
            {
                foreach (var item in oldBasket.BasketPositions)
                {
                    BasketPosition found = ordered.BasketPositions.Find(x => x.Event.Id == item.Event.Id);
                    if (found != null)
                    {
                        item.Quantity -= found.Quantity;
                    }
                }

                SaveEventsIdInCookie(oldBasket);
            }
        }
    }
}