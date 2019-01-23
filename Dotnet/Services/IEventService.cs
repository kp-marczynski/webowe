using Shop.Entities;

namespace Shop.Services
{
    public interface IEventService
    {
        Event FindById(int eventId);
    }
}