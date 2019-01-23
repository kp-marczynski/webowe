using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class EventDetailsModel : LayoutModel
    {
        public Event Event { get; set; }

        public List<string> AdditionalInfo { get; set; } = new List<string>();

        private readonly IEventService _eventService;
        private readonly IOrderService _orderService;

        public EventDetailsModel(ILayoutService layoutService, IEventService eventService, IOrderService orderService) :
            base(layoutService)
        {
            _eventService = eventService;
            _orderService = orderService;
        }

        public IActionResult OnGet(int eventId)
        {
            var initResult = InitializeLayout();
            if (initResult is RedirectResult)
            {
                return initResult;
            }

            Event = _eventService.FindById(eventId);
            if (Event != null)
            {
                Event.NumberOfAvailableTickets =
                    Event.NumberOfAvailableTickets - _orderService.CountSoldTickets(eventId);
                Event.AgeRange = Event.AgeRange == "ALL" ? "Impreza dozwolona dla wszystkich" : "Tylko dla dorosłych";
                AdditionalInfo = new List<string>();
                if (!string.IsNullOrEmpty(Event.AdditionalInfo))
                {
                    if (Event.AdditionalInfo.Contains("DOGS"))
                    {
                        AdditionalInfo.Add("Można przyjść ze zwierzętami");
                    }

                    if (Event.AdditionalInfo.Contains("DANGER"))
                    {
                        AdditionalInfo.Add("Impreza o podwyższonym ryzyku");
                    }

                    if (Event.AdditionalInfo.Contains("VIP"))
                    {
                        AdditionalInfo.Add("Wydzielona strefa dla VIPów");
                    }

                    if (Event.AdditionalInfo.Contains("ALCOHOL"))
                    {
                        AdditionalInfo.Add("Możliwy zakup alkoholu");
                    }
                }
            }

            return Page();
        }
    }
}