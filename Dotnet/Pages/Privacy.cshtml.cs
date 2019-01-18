namespace Shop.Pages
{
    public class PrivacyModel : LayoutModel
    {
        public PrivacyModel(ShopDbContext ShopDbContext) : base(ShopDbContext)
        {
        }

        public void OnGet()
        {
            OnGetBase();
        }
    }
}