using Shop.Pages;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages

{
    public class OrdersModel: LayoutModel
    {
        public OrdersModel(ILayoutService layoutService) : base(layoutService)
        {
        }

        public void OnGet()
        {
            initializeLayout();
        }
    }
}