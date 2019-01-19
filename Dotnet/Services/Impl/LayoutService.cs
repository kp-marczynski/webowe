using Microsoft.AspNetCore.Http;

namespace Shop.Services.Impl
{
    public class LayoutService : ILayoutService
    {
        private readonly IUserService _userService;
        private readonly IBasketService _basketService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(IUserService userService, IBasketService basketService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserEmail()
        {
            return _userService.GetCurrentUser()?.Email;
        }

        public int GetItemsInBasketCount()
        {
            return _basketService.GetItemsInBasket().GetBasketCount();
        }

        public string GetTheme()
        {
            var theme = _httpContextAccessor.HttpContext.Request.Cookies["theme"];
            return string.IsNullOrEmpty(theme) ? "LIGHT_THEME" : theme;
        }
    }
}