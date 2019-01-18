using Shop.BusinessObjects;

namespace Shop.Pages
{
    public class IndexModel : LayoutModel
    {
        public BasketSet BasketSet = new BasketSet();

        public IndexModel(ShopDbContext ShopDbContext) : base(ShopDbContext)
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