using System.Security.Cryptography.X509Certificates;
using CjDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace CjDinner.Infrastructure.Persistence;

public class CjDinnerDbContext : DbContext
{
    public CjDinnerDbContext(DbContextOptions<CjDinnerDbContext> options) : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; } = null!;
}