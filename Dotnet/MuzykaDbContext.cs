using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Sklep.Entities;

namespace Sklep
{
    public class MuzykaDbContext: DbContext
    {
        public MuzykaDbContext(DbContextOptions options) : base(options)
        {
//            Database. = sql => Debug.Write(sql);
        }
        
        public DbSet<User> users { get; set; }

        public DbSet<Event> events { get; set; }
        
        public DbSet<BaseOrder> baseOrders { get; set; }
        
        public DbSet<OrderEvent> OrderEvents { get; set; }
    }
}
