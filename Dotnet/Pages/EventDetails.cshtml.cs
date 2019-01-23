using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class EventDetailsModel : LayoutModel
    {
        public Event Event { get; set; }

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
            }

            return Page();
        }
        
    }
}