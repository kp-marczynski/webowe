using System.Collections.Generic;
using Shop.BusinessObjects;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages

{
    public class OrderHistoryModel : LayoutModel
    {
        public List<OrderPosition> OrdersList { get; set; }

        private IOrderService _orderService;
        public OrderHistoryModel(ILayoutService layoutService, IOrderService orderService) : base(layoutService)
        {
            _orderService = orderService;
        }

        public void OnGet()
        {
            initializeLayout();
            OrdersList = _orderService.getCurrentUserOrders();
        }
    }
}