using Shop.Entities;

namespace Shop.Repositories
{
    public interface IEventRepository
    {
        Event FindById(int eventId);
    }
}