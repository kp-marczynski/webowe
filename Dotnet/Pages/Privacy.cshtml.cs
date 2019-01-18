namespace Sklep.Pages
{
    public class PrivacyModel : LayoutModel
    {
        public PrivacyModel(MuzykaDbContext muzykaDbContext) : base(muzykaDbContext)
        {
        }

        public void OnGet()
        {
            OnGetBase();
        }
    }
}