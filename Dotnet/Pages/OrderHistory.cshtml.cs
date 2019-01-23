using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.BusinessObjects;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages

{
    public class OrderHistoryModel : LayoutModel
    {
        public List<OrderPosition> OrdersList { get; set; }

        private readonly IOrderService _orderService;

        public OrderHistoryModel(ILayoutService layoutService, IOrderService orderService) : base(layoutService)
        {
            _orderService = orderService;
        }

        public IActionResult OnGet()
        {
            var initResult = InitializeLayout();
            if (initResult is RedirectResult)
            {
                return initResult;
            }

            OrdersList = _orderService.getCurrentUserOrders();
            return Page();
        }
    }
}