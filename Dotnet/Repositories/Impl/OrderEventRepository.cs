using System.Collections.Generic;
using System.Linq;
using Shop.Entities;

namespace Shop.Repositories.Impl
{
    public class OrderEventRepository : IOrderEventRepository
    {
        private readonly ShopDbContext _shopDbContext;
        private readonly IBaseOrderRepository _baseOrderRepository;

        public OrderEventRepository(ShopDbContext shopDbContext, IBaseOrderRepository baseOrderRepository)
        {
            _shopDbContext = shopDbContext;
            _baseOrderRepository = baseOrderRepository;
        }

        public void SaveAll(List<OrderEvent> orderEvents)
        {
            using (var shopDbContext = ShopDbContext.GetInstance())
            {
                shopDbContext.OrderEvents.AddRange(orderEvents);
                shopDbContext.SaveChanges();
            }
        }

        public List<OrderEvent> FindByOrderId(int orderId)
        {
            return ShopDbContext.GetInstance().OrderEvents.Where(x => x.OrderId == orderId).ToList();
        }

        public int CountSoldTickets(int eventId)
        {
            var wrongOrdersIds = _baseOrderRepository.FindWrongOrdersIds();
            return ShopDbContext.GetInstance().OrderEvents.Where(x =>
                x.EventId == eventId &&
                !wrongOrdersIds.Contains(x.OrderId)
            ).Sum(y => y.Quantity);
        }
    }
}