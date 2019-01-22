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

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<BaseOrder> BaseOrders { get; set; }

        public DbSet<OrderEvent> OrderEvents { get; set; }

        public static ShopDbContext GetInstance()
        {
            return new ShopDbContext(_dbContextOptions);
        }
    }
}