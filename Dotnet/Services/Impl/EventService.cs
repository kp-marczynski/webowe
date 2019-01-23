using Shop.Entities;
using Shop.Repositories;

namespace Shop.Services.Impl
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Event FindById(int eventId)
        {
            return _eventRepository.FindById(eventId);
        }
    }
}