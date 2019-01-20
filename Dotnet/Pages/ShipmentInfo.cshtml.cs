using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.BusinessObjects;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class ShipmentInfoModel : LayoutModel
    {
//        public List<string> PaymentMethodsList = new List<string>{"gotówką", "przelewem"};
        private IOrderService _orderService;
        public ShipmentInfoModel(ILayoutService layoutService, IOrderService orderService) : base(layoutService)
        {
            _orderService = orderService;
        }

        [BindProperty] public ShipmentInfo ShipmentInfo { get; set; }

        public IActionResult OnGet()
        {
            var currentOrderState = _orderService.CurrentOrderState();
            if (currentOrderState != null)
            {
                switch (currentOrderState)
                {
                    case OrderState.Basket:
                        return RedirectToPage("Basket");
                    case OrderState.Shipment:
                        break;
                    case OrderState.Summary:
                        return RedirectToPage("OrderSummary");
                }
            }
            else
            {
                _orderService.SetCurrentOrderState(OrderState.Basket);
            }
            initializeLayout();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model is not valid");
                initializeLayout();
                return Page();
            }

            _orderService.SetCurrentOrderState(OrderState.Summary);
            _orderService.SaveShipmentInfoInSession(ShipmentInfo);
            return RedirectToPage("OrderSummary");
//            return RedirectToPage("OrderSummary", "SingleOrder", ShipmentInfo);
        }
    }
}