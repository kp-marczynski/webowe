using Sklep.BusinessObjects;

namespace Sklep.Pages
{
    public class IndexModel : LayoutModel
    {
        public BasketSet BasketSet = new BasketSet();

        public IndexModel(MuzykaDbContext muzykaDbContext) : base(muzykaDbContext)
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