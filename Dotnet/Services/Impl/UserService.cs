using Microsoft.AspNetCore.Http;
using Shop.Entities;
using Shop.Repositories;

namespace Shop.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRepository _userRepository;

        public UserService(IHttpContextAccessor httpContext,
            IUserRepository userRepository)
        {
            _httpContext = httpContext;
            _userRepository = userRepository;
        }

        public User GetCurrentUser()
        {
            var userToken = _httpContext.HttpContext.Request.Cookies["token"];
            if (!string.IsNullOrEmpty(userToken))
            {
                return _userRepository.FindByToken(userToken);
            }

            return null;
        }
    }
}