using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.BusinessObjects;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class OrderSummaryModel : LayoutModel
    {
        [BindProperty] public ShipmentInfo ShipmentInfo { get; set; }
        [BindProperty] public CartCollection CartCollection { get; set; }
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        public List<double> Price;

        public OrderSummaryModel(ILayoutService layoutService, IOrderService orderService, IBasketService basketService)
            : base(layoutService)
        {
            _orderService = orderService;
            _basketService = basketService;
        }

        public IActionResult OnGet()
        {
            CartCollection = _basketService.GetOrderItems();
            ShipmentInfo = _orderService.GetShipmentInfoFromSession() ?? new ShipmentInfo();

            InitializeLayout();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                InitializeLayout();
                return Page();
            }

            _orderService.SaveCurrentOrderInDb(CartCollection, ShipmentInfo);
            _basketService.RemoveOrderedItemsFromCookie();

            return RedirectToPage("OrderHistory");
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