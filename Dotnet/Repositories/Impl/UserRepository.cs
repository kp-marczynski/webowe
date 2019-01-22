using System;
using System.Linq;
using Shop.Entities;

namespace Shop.Repositories.Impl
{
    public class UserRepository: IUserRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public UserRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public User FindByToken(string token)
        {
//            return _shopDbContext.users.Find(token);
            var temp = ShopDbContext.getInstance().users.Where(x => x.Token == token).ToList();
            if (temp.Count == 1)
            {
                return temp[0];
            }

            return null;
        }
    }
}