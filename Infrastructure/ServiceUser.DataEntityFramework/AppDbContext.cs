using Microsoft.EntityFrameworkCore;
using ServiceUser.Domain.Entities;

namespace ServiceUser.DataEntityFramework
{
    public class AppDbContext : DbContext
    {
        DbSet<UserProfile> UserProfiles => Set<UserProfile>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

    }
}
