using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : LayoutModel
    {
        public ErrorModel(ShopDbContext ShopDbContext, string requestId) : base(ShopDbContext)
        {
            RequestId = requestId;
        }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet()
        {
            OnGetBase();
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}