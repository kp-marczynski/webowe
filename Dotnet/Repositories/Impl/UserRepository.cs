using System.Linq;
using Shop.Entities;

namespace Shop.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public UserRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public User FindByToken(string token)
        {
//            return _shopDbContext.users.Find(token);
            var temp = ShopDbContext.GetInstance().Users.Where(x => x.Token == token).ToList();
            return temp.Count == 1 ? temp[0] : null;
        }
    }
}