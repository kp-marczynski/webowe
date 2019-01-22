using System.Collections.Generic;
using Shop.Entities;

namespace Shop.Repositories
{
    public interface IBaseOrderRepository
    {
        List<BaseOrder> FindAllByUserId(int userId);
        List<int> FindWrongOrdersIds();
        BaseOrder SaveAndFlush(BaseOrder baseOrder);
        BaseOrder Update(BaseOrder baseOrder);
    }
}