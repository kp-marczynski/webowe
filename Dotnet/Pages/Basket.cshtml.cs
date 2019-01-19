using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.BusinessObjects;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class BasketModel : LayoutModel
    {
        [BindProperty] public BasketSet BasketSet { get; set; } = new BasketSet();

        private IBasketService _basketService;

        public BasketModel(ILayoutService layoutService, IBasketService basketService) : base(layoutService)
        {
            _basketService = basketService;
        }

        public void OnGet()
        {
            initializeLayout();
            BasketSet = _basketService.GetItemsInBasket();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            foreach (var item in ModelState)
            {
                Console.WriteLine(item.ToString());
            }
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model is not valid");
                initializeLayout();
                return Page();
            }

            _basketService.SaveBasketInCookie(BasketSet);
            return RedirectToPage("ShipmentInfo");
        }
    }
}