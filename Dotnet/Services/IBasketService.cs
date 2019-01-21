using Shop.BusinessObjects;

namespace Shop.Services
{
    public interface IBasketService
    {
        CartCollection GetItemsInBasket();
        void SaveBasketInCookie(CartCollection cartCollection);
        void RemoveOrderedItemsFromCookie();
        CartCollection GetOrderItems();
    }
}