using System.Collections.Generic;
using Shop.Entities;

namespace Shop.Repositories
{
    public interface IOrderEventRepository
    {
        void SaveAll(List<OrderEvent> orderEvents);
        List<OrderEvent> FindByOrderId(int orderId);
        int CountSoldTickets(int eventId);
    }
}