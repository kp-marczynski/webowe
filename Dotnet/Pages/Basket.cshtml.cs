using Shop.BusinessObjects;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class BasketModel : LayoutModel
    {
        public BasketSet BasketSet = new BasketSet();

        private IBasketService _basketService;
        public BasketModel(ILayoutService layoutService, IBasketService basketService) : base(layoutService)
        {
            _basketService = basketService;
        }

        public void OnGet()
        {
            initializeLayout();
            BasketSet = _basketService.GetItemsInBasket();
        }
    }
}