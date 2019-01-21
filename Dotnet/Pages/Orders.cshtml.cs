using System.Collections.Generic;
using Shop.BusinessObjects;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages

{
    public class OrdersModel : LayoutModel
    {
        public List<CompleteOrder> OrdersList { get; set; }

        public OrdersModel(ILayoutService layoutService) : base(layoutService)
        {
        }

        public void OnGet()
        {
            initializeLayout();
        }
    }
}