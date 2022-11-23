using ApiShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiShop.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        internal object toList()
        {
            throw new NotImplementedException();
        }

        internal bool Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
