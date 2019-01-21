using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.BusinessObjects;
using Shop.BusinessObjects.Enums;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class OrderSummaryModel : LayoutModel
    {
        [BindProperty] public ShipmentInfo ShipmentInfo { get; set; }
        [BindProperty] public OrderCollection OrderCollection { get; set; }
        private IOrderService _orderService;
        private IBasketService _basketService;
        public List<float> price;

        public OrderSummaryModel(ILayoutService layoutService, IOrderService orderService, IBasketService basketService)
            : base(layoutService)
        {
            _orderService = orderService;
            _basketService = basketService;
        }

        public IActionResult OnGet()
        {
            switch (_orderService.CurrentOrderState())
            {
                case OrderState.Basket:
                    return RedirectToPage("Basket");
                case OrderState.Shipment:
                    return RedirectToPage("ShipmentInfo");
                case OrderState.Summary:
                    break;
                default:
                    _orderService.SetCurrentOrderState(OrderState.Basket);
                    return RedirectToPage("Basket");
            }

            OrderCollection = _basketService.GetOrderItems();
            ShipmentInfo = _orderService.GetShipmentInfoFromSession() ?? new ShipmentInfo();

            initializeLayout();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                initializeLayout();
                return Page();
            }

            _orderService.SaveCurrentOrderInDb();
            _basketService.RemoveOrderedItemsFromCookie();

            return RedirectToPage("Orders");
//            return RedirectToPage("OrderSummary", "SingleOrder", ShipmentInfo);
        }

//        public void OnGetSingleOrder(ShipmentInfo shipmentInfo)
//        {
//            initializeLayout();
//            ShipmentInfo = shipmentInfo;
//        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("ShipmentInfo");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Basket");
        }
    }
}