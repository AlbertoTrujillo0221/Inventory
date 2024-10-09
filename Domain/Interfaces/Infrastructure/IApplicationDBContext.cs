using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces.Infrastructure
{
    public interface IApplicationDBContext
    {
        DbSet<Product> Products { get; }
    }
}
