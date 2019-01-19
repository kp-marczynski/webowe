using Shop.Pages;
using Shop.Pages.Shared;

namespace Shop.Pages

{
    public class OrdersModel: LayoutModel
    {
        public OrdersModel(ShopDbContext ShopDbContext) : base(ShopDbContext)
        {
        }

        public void OnGet()
        {
            OnGetBase();
        }
    }
}