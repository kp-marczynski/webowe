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
        [BindProperty] public CartCollection CartCollection { get; set; } = new CartCollection();

        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public BasketModel(ILayoutService layoutService, IBasketService basketService, IOrderService orderService) :
            base(layoutService)
        {
            _basketService = basketService;
            _orderService = orderService;
        }

        public IActionResult OnGet()
        {
            var initResult = InitializeLayout();
            if (initResult is RedirectResult)
            {
                return initResult;
            }

            CartCollection = _basketService.GetItemsInBasket();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model is not valid");
                var initResult = InitializeLayout();
                if (initResult is RedirectResult)
                {
                    return initResult;
                }

                ItemsInCartCount = "?";
                return Page();
            }

            _basketService.SaveBasketInCookie(CartCollection);
            return RedirectToPage("ShipmentInfo");
        }
    }
}