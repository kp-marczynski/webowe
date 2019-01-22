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
            ShipmentInfo = _orderService.GetShipmentInfoFromSession();
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