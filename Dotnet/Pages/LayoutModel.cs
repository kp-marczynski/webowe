using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Sklep.Pages
{
    public abstract class LayoutModel : PageModel
    {
        public LayoutModel(MuzykaDbContext muzykaDbContext)
        {
            _dbContext = muzykaDbContext;
        }

        public string UserToken { get; set; }
        public string Theme { get; set; }
        public List<string> ItemsInCart { get; set; }
        public int ItemsInCartCount { get; set; }
        public readonly string PhpAddress = "http://localhost:8080";
        public List<Event> events = new List<Event>();

        public bool ShowUserToken => !string.IsNullOrEmpty(CurrentUserEmail);

        private MuzykaDbContext _dbContext;
        public string CurrentUserEmail { get; set; }

        public void OnGet()
        {
            Theme = Request.Cookies["theme"];
            if (string.IsNullOrEmpty(Theme))
            {
                Theme = "LIGHT_THEME";
            }

            UserToken = Request.Cookies["token"];
            if (!string.IsNullOrEmpty(UserToken))
            {
                List<User> users = _dbContext.users.Where(x => x.Token == UserToken).ToList();
                if (users.Count == 1)
                {
                    CurrentUserEmail = users[0].Email;
                }
            }

//            if (string.IsNullOrEmpty(CurrentUserEmail))
//            {
//                Redirect("http://localhost:8080");    
//            }
            
            var itemsJson = Request.Cookies["items-in-cart"];
            if (!string.IsNullOrEmpty(itemsJson))
            {
                ItemsInCart = JsonConvert.DeserializeObject<List<string>>(itemsJson);
                ItemsInCartCount = ItemsInCart.Count;
                foreach (var item in ItemsInCart)
                {
                    var temp = _dbContext.events.Where(x => x.Id.ToString() == item).ToList();
                    if (temp.Count == 1)
                    {
                        events.Add(temp[0]);
                    }
                }
            }
        }
    }
}