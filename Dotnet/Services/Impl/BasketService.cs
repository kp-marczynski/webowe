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

        public BasketService(IHttpContextAccessor httpContextAccessor, ShopDbContext shopDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _shopDbContext = shopDbContext;
        }

        public BasketSet GetItemsInBasket()
        {
            var basketSet = new BasketSet();
            var itemsJson = _httpContextAccessor.HttpContext.Request.Cookies["items-in-cart"];
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

            return basketSet;
        }
    }
}