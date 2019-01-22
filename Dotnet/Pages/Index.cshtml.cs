using Microsoft.AspNetCore.Mvc;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class IndexModel: LayoutModel
    {
        public IActionResult OnGet()
        {
//            InitializeLayout();
            return RedirectToPage("Basket");
        }

        public IndexModel(ILayoutService layoutService) : base(layoutService)
        {
        }
    }
}