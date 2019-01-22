using System.Collections.Generic;
using System.Linq;
using Shop.BusinessObjects.Enums;
using Shop.Entities;

namespace Shop.Repositories.Impl
{
    public class BaseOrderRepository : IBaseOrderRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public BaseOrderRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public List<BaseOrder> FindAllByUserId(int userId)
        {
            return _shopDbContext.baseOrders.Where(x => x.UserId == userId).ToList();
        }

        public List<int> FindWrongOrdersIds()
        {
            return _shopDbContext.baseOrders.Where(z =>
                    z.OrderStatus == OrderProcessingState.NotVerified.ToString()
                    || z.OrderStatus == OrderProcessingState.VerificationFailed.ToString())
                .ToList().Select(x => x.Id).ToList();
        }

        public BaseOrder SaveAndFlush(BaseOrder baseOrder)
        {
            _shopDbContext.baseOrders.Add(baseOrder);
            _shopDbContext.SaveChanges();
            return baseOrder;
        }

        public BaseOrder Update(BaseOrder baseOrder)
        {
            _shopDbContext.baseOrders.Update(baseOrder);
            _shopDbContext.SaveChanges();
            return baseOrder;
        }
    }
}