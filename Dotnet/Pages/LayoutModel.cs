using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Sklep.Pages
{
    public abstract class LayoutModel : PageModel
    {
        public string UserToken { get; set; }
        public List<string> ItemsInCart { get; set; }
        public int ItemsInCartCount { get; set; }

        public bool ShowUserToken => !string.IsNullOrEmpty(UserToken);
        public void OnGet()
        {
            UserToken = Request.Cookies["token"];
            
            var itemsJson = Request.Cookies["items-in-cart"];
            if (!string.IsNullOrEmpty(itemsJson))
            {
                ItemsInCart = JsonConvert.DeserializeObject<List<string>>(itemsJson);
                ItemsInCartCount = ItemsInCart.Count;
            }
        }
    }
}