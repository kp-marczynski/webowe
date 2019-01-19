using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shop.Entities;

namespace Shop.Pages.Shared
{
    public abstract class LayoutModel : PageModel
    {
        public LayoutModel(ShopDbContext ShopDbContext)
        {
            _dbContext = ShopDbContext;
        }

        public string UserToken { get; set; }
        public string Theme { get; set; }
        public List<string> ItemsInCart { get; set; }
        [TempData] public int ItemsInCartCount { get; set; }
        public readonly string PhpAddress = "http://localhost:8080";
        public List<Event> events = new List<Event>();

        public bool ShowUserToken => !string.IsNullOrEmpty(CurrentUserEmail);
        public bool ShowCartCount => ItemsInCartCount != null && ItemsInCartCount != 0;

        private ShopDbContext _dbContext;
        [TempData] public string CurrentUserEmail { get; set; }

        public void OnGetBase()
        {
            initializeCookies();
        }

        public void initializeCookies()
        {
            processUserCookie();
            processThemeCookie();
            processCartCookie();
        }

        public void processCartCookie()
        {
            var itemsJson = Request.Cookies["items-in-cart"];
            if (!string.IsNullOrEmpty(itemsJson))
            {
                ItemsInCart = JsonConvert.DeserializeObject<List<string>>(itemsJson);
                ItemsInCartCount = ItemsInCart.Count;
                foreach (var item in ItemsInCart)
                {
                    var temp = _dbContext.events.Where(x => x.Id.ToString() == item).ToList();
//                    var first = _dbContext.events.Where(x => x.Id == 1).OrderByDescending(x => x.AdditionalInfo).First();
                    if (temp.Count == 1)
                    {
                        events.Add(temp[0]);
                    }
                }
            }
        }

        public void processUserCookie()
        {
            UserToken = Request.Cookies["token"];
            if (!string.IsNullOrEmpty(UserToken))
            {
                List<User> users = _dbContext.users.Where(x => x.Token == UserToken).ToList();
                if (users.Count == 1)
                {
                    CurrentUserEmail = users[0].Email;
                }
            }
        }

        public void processThemeCookie()
        {
            Theme = Request.Cookies["theme"];
            if (string.IsNullOrEmpty(Theme))
            {
                Theme = "LIGHT_THEME";
            }
        }
    }
}