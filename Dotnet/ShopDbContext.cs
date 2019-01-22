using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop
{
    public class ShopDbContext : DbContext
    {
        private static DbContextOptions _dbContextOptions;
        public ShopDbContext(DbContextOptions options) : base(options)
        {
            _dbContextOptions = options;
        }

        public DbSet<User> users { get; set; }

        public DbSet<Event> events { get; set; }

        public DbSet<BaseOrder> baseOrders { get; set; }

        public DbSet<OrderEvent> OrderEvents { get; set; }

        public static ShopDbContext getInstance()
        {
            return new ShopDbContext(_dbContextOptions);
        }
    }
}