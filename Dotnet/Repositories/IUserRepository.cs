using Shop.Entities;

namespace Shop.Repositories
{
    public interface IUserRepository
    {
        User FindByToken(string token);
    }
}