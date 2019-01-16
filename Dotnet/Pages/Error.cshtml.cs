using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Sklep.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : LayoutModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        new public void OnGet()
        {
            base.OnGet();
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}