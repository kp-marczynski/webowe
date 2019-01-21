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

        private IBasketService _basketService;
        private IOrderService _orderService;

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

            initializeLayout();
            CartCollection = _basketService.GetItemsInBasket();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("Modelstate:");
            foreach (var item in ModelState)
            {
                Console.WriteLine(item.ToString());
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model is not valid");
                initializeLayout();
                ItemsInCartCount = "?";
                return Page();
            }

            Console.WriteLine("Hello from postasync");
            foreach (var item in CartCollection.BasketPositions)
            {
                Console.WriteLine(item.Event.Name+": "+item.Quantity);
            }
            _basketService.SaveBasketInCookie(CartCollection);
            _orderService.SetCurrentOrderState(OrderState.Shipment);
            return RedirectToPage("ShipmentInfo");
        }
    }
}