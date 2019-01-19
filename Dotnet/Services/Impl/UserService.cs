using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Shop.Entities;
using System.Linq;

namespace Shop.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly ShopDbContext _shopDbContext;

        public UserService(IHttpContextAccessor httpContext, ShopDbContext shopDbContext)
        {
            _httpContext = httpContext;
            _shopDbContext = shopDbContext;
        }

        public User GetCurrentUser()
        {
            var userToken = _httpContext.HttpContext.Request.Cookies["token"];
            if (!string.IsNullOrEmpty(userToken))
            {
                List<User> users = _shopDbContext.users.Where(x => x.Token == userToken).ToList();
                if (users.Count == 1)
                {
                    return users[0];
                }
            }

            return null;
        }
    }
}