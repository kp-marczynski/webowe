using Shop.BusinessObjects;

namespace Shop.Services
{
    public interface IBasketService
    {
        OrderCollection GetItemsInBasket();
        void SaveBasketInCookie(OrderCollection orderCollection);
        void RemoveOrderedItemsFromCookie();
        OrderCollection GetOrderItems();
    }
}