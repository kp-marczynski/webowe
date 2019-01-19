using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.BusinessObjects;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class ShipmentInfoModel: LayoutModel
    {
        public ShipmentInfoModel(ILayoutService layoutService) : base(layoutService)
        {
        }

        [BindProperty]
        public ShipmentInfo ShipmentInfo { get; set; }
        
        public void OnGet()
        {
            initializeLayout();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model is not valid");
                initializeLayout();
                return Page();
            }

            //todo save somewhere address
            return RedirectToPage("OrderSummary");
        }
    }
}