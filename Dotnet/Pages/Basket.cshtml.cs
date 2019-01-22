using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.BusinessObjects;
using Shop.BusinessObjects.Enums;
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
            switch (_orderService.CurrentOrderState())
            {
                case OrderState.Basket:
                    break;
                case OrderState.Shipment:
                    return RedirectToPage("ShipmentInfo");
                case OrderState.Summary:
                    return RedirectToPage("OrderSummary");
                default:
                    _orderService.SetCurrentOrderState(OrderState.Basket);
                    return RedirectToPage("Basket");
            }

            InitializeLayout();
            CartCollection = _basketService.GetItemsInBasket();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model is not valid");
                InitializeLayout();
                ItemsInCartCount = "?";
                return Page();
            }

            _basketService.SaveBasketInCookie(CartCollection);
            _orderService.SetCurrentOrderState(OrderState.Shipment);
            return RedirectToPage("ShipmentInfo");
        }
    }
}