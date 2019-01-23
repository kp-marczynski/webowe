using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.BusinessObjects;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class ShipmentInfoModel : LayoutModel
    {
//        public Dictionary<string, double> ShipmentMethod = new Dictionary<string, double>
//        {
//            {"Kurier", 15.5},
//            {"List Polecony", 7.0},
//            {"Odbiór Osobisty po przedpłacie", 0.0}
//        };
        public readonly List<ShipmentOption> ShipmentOptions = new List<ShipmentOption>
        {
            new ShipmentOption("Kurier", 15.5),
            new ShipmentOption("List Polecony", 7.0),
            new ShipmentOption("Odbiór Osobisty po przedpłacie", 0.0)
        };

        private readonly IOrderService _orderService;

        public ShipmentInfoModel(ILayoutService layoutService, IOrderService orderService) : base(layoutService)
        {
            _orderService = orderService;
        }

        [BindProperty] public ShipmentInfo ShipmentInfo { get; set; }
        [BindProperty] public string ShipmentMethod { get; set; }

        public IActionResult OnGet()
        {
            ShipmentInfo = _orderService.GetShipmentInfoFromSession();
            var initResult = InitializeLayout();
            return initResult is RedirectResult ? initResult : Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model is not valid");
                var initResult = InitializeLayout();
                return initResult is RedirectResult ? initResult : Page();
            }

            var shipmentOptions = ShipmentOptions.Where(x => x.ShipmentMethod == ShipmentMethod).ToList();
            if (shipmentOptions.Count == 1)
            {
                ShipmentInfo.ShipmentOption = shipmentOptions[0];
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