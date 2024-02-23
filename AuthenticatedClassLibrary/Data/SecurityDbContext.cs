using Microsoft.EntityFrameworkCore;
namespace AuthenticatedClassLibrary;
public class SecurityDbContext : DbContext
{
    public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
        : base(options)
    {
    }

    // Define DbSets for your security entities here
    /// Defines the DbSet for the Product entity
    public DbSet<Product> Products { get; set; }
    
    /// Defines the DbSet for the Categories entity
    public DbSet<Category> Categories { get; set; }

    /// Defines the DbSet for the Shoppingcarts entity
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

}
