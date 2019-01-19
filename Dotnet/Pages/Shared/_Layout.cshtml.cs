using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Services;

namespace Shop.Pages.Shared
{
    public abstract class LayoutModel : PageModel
    {
        public LayoutModel(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        private readonly ILayoutService _layoutService;

        public string Theme { get; set; }
        public int ItemsInCartCount { get; set; }
        public readonly string PhpAddress = "http://localhost:8080";
        public string CurrentUserEmail { get; set; }
        
        public bool ShowUserToken => !string.IsNullOrEmpty(CurrentUserEmail);
        public bool ShowCartCount => ItemsInCartCount != 0;

        public void initializeLayout()
        {
            CurrentUserEmail = _layoutService.GetCurrentUserEmail();
            Theme = _layoutService.GetTheme();
            ItemsInCartCount = _layoutService.GetItemsInBasketCount();
            Console.WriteLine("Layout initialized");
        }
    }
}