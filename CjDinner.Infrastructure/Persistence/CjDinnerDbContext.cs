using System.Security.Cryptography.X509Certificates;
using CjDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CjDinner.Infrastructure.Persistence;

public class CjDinnerDbContext : DbContext
{
    public CjDinnerDbContext(DbContextOptions<CjDinnerDbContext> options) : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CjDinnerDbContext).Assembly);
        modelBuilder.Model.GetEntityTypes()
        .SelectMany(e => e.GetProperties())
        .Where(p => p.IsPrimaryKey())
        .ToList()
        .ForEach(p => p.ValueGenerated = ValueGenerated.Never);
        base.OnModelCreating(modelBuilder);
    }
}