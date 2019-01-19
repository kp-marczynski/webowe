using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class ShipmentInfoModel: LayoutModel
    {
        public ShipmentInfoModel(ILayoutService layoutService) : base(layoutService)
        {
        }

        public void OnGet()
        {
            initializeLayout();
        }
    }
}