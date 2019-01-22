using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class PrivacyModel : LayoutModel
    {
        public PrivacyModel(ILayoutService layoutService) : base(layoutService)
        {
        }

        public void OnGet()
        {
            InitializeLayout();
        }
    }
}