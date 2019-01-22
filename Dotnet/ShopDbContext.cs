using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }

        public DbSet<Event> events { get; set; }

        public DbSet<BaseOrder> baseOrders { get; set; }

        public DbSet<OrderEvent> OrderEvents { get; set; }
    }
}