namespace Shop.Services
{
    public interface ILayoutService
    {
        string GetCurrentUserEmail();
        int GetItemsInBasketCount();
        string GetTheme();
    }
}