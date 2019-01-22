using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.BusinessObjects;
using Shop.BusinessObjects.Enums;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class ShipmentInfoModel : LayoutModel
    {
//        public List<string> PaymentMethodsList = new List<string>{"gotówką", "przelewem"};
        private readonly IOrderService _orderService;
        public ShipmentInfoModel(ILayoutService layoutService, IOrderService orderService) : base(layoutService)
        {
            _orderService = orderService;
        }

        [BindProperty] public ShipmentInfo ShipmentInfo { get; set; }

        public IActionResult OnGet()
        {

            switch (_orderService.CurrentOrderState())
            {
                case OrderState.Basket:
                    return RedirectToPage("Basket");
                case OrderState.Shipment:
                    break;
                case OrderState.Summary:
                    return RedirectToPage("OrderSummary");
                default:
                    _orderService.SetCurrentOrderState(OrderState.Basket);
                    return RedirectToPage("Basket");
            }

            InitializeLayout();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model is not valid");
                InitializeLayout();
                return Page();
            }

            _orderService.SetCurrentOrderState(OrderState.Summary);
            _orderService.SaveShipmentInfoInSession(ShipmentInfo);
            return RedirectToPage("OrderSummary");
//            return RedirectToPage("OrderSummary", "SingleOrder", ShipmentInfo);
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("Basket");
        }
    }
}