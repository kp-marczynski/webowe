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
            return ShopDbContext.getInstance().baseOrders.Where(x => x.UserId == userId).ToList();
        }

        public List<int> FindWrongOrdersIds()
        {
            return ShopDbContext.getInstance().baseOrders.Where(z =>
                    z.OrderStatus == OrderProcessingState.NotVerified.ToString()
                    || z.OrderStatus == OrderProcessingState.VerificationFailed.ToString())
                .ToList().Select(x => x.Id).ToList();
        }

        public BaseOrder SaveAndFlush(BaseOrder baseOrder)
        {
            using (var shopDbContext = ShopDbContext.getInstance())
            {
                shopDbContext.baseOrders.Add(baseOrder);
                shopDbContext.SaveChanges();
                return baseOrder;
            }
        }

        public BaseOrder Update(BaseOrder baseOrder)
        {
            using (var shopDbContext = ShopDbContext.getInstance())
            {
                shopDbContext.baseOrders.Update(baseOrder);
                shopDbContext.SaveChanges();
                return baseOrder;
            }
        }
    }
}