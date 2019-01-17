using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
    }
}
