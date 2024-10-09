using Domain.Entities;
using Domain.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDBContext
    {
        public DbSet<Product> Products {  get; set; }
    }
}
