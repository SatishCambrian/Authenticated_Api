using Microsoft.EntityFrameworkCore;
namespace Authenticated.Data.SecurityDbContext;
public class SecurityDbContext : DbContext
{
    public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
        : base(options)
    {
    }


}
