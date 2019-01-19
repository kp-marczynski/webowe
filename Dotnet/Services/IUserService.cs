using Shop.Entities;

namespace Shop.Services
{
    public interface IUserService
    {
        User GetCurrentUser();
    }
}