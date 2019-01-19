using Shop.Pages.Shared;

namespace Shop.Pages
{
    public class ShipmentInfoModel: LayoutModel
    {
        public ShipmentInfoModel(ShopDbContext ShopDbContext) : base(ShopDbContext)
        {
        }

        public void OnGet()
        {
            OnGetBase();
        }
    }
}