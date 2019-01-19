using Shop.BusinessObjects;
using Shop.Pages.Shared;

namespace Shop.Pages
{
    public class BasketModel : LayoutModel
    {
        public BasketSet BasketSet = new BasketSet();

        public BasketModel(ShopDbContext ShopDbContext) : base(ShopDbContext)
        {
        }

        public void OnGet()
        {
            OnGetBase();
            foreach (var ev in events)
            {
                BasketSet.addToBasket(ev);
            }
        }
    }
}