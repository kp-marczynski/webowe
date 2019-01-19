using Shop.BusinessObjects;

namespace Shop.Services
{
    public interface IBasketService
    {
        BasketSet GetItemsInBasket();
    }
}