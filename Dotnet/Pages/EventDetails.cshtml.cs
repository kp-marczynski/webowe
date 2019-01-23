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

        public EventDetailsModel(ILayoutService layoutService, IEventService eventService) : base(layoutService)
        {
            _eventService = eventService;
        }

        public IActionResult OnGet(int eventId)
        {
            var initResult = InitializeLayout();
            if (initResult is RedirectResult)
            {
                return initResult;
            }

            Event = _eventService.FindById(eventId);
            return Page();
        }
    }
}