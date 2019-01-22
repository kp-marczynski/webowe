using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : LayoutModel
    {
        public ErrorModel(string requestId, ILayoutService layoutService) : base(layoutService)
        {
            RequestId = requestId;
        }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet()
        {
            InitializeLayout();
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}