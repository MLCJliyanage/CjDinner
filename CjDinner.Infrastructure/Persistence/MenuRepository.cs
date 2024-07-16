using CjDinner.Application.Common.Interfaces.Persistence;
using CjDinner.Domain.MenuAggregate;

namespace CjDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}