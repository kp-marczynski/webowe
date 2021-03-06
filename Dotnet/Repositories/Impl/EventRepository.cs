using Shop.Entities;

namespace Shop.Repositories.Impl
{
    public class EventRepository : IEventRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public EventRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public Event FindById(int eventId)
        {
            return ShopDbContext.GetInstance().Events.Find(eventId);
        }
    }
}