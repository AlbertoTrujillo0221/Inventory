using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Factories
{
    public class ApplicationDbContextFactory(DbContextOptions<ApplicationDbContext> options) : IDbContextFactory
    {
        public DbContext Create()
        {
            return new ApplicationDbContext(options);
        }
    }
}
