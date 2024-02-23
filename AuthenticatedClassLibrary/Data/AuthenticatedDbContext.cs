using Microsoft.EntityFrameworkCore;

namespace YourProject.Data
{
    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext(DbContextOptions
<SecurityDbContext>
    options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}