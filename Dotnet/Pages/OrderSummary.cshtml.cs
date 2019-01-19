using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class OrderSummaryModel: LayoutModel
    {
        public OrderSummaryModel(ILayoutService layoutService) : base(layoutService)
        {
        }

        public void OnGet()
        {
            initializeLayout();
        }
    }
}