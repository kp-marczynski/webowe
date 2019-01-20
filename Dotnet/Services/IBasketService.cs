using Shop.BusinessObjects;

namespace Shop.Services
{
    public interface IBasketService
    {
        BasketSet GetItemsInBasket();
        void SaveBasketInCookie(BasketSet basketSet);
        void RemoveOrderedItemsFromCookie();
        BasketSet GetOrderItems();
    }
}