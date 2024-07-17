using CjDinner.Application.Common.Interfaces.Persistence;
using CjDinner.Domain.MenuAggregate;

namespace CjDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly CjDinnerDbContext _dbContext;

    public MenuRepository(CjDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }
}