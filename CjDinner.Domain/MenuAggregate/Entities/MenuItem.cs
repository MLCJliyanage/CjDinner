

using CjDinner.Domain.Common.Models;
using CjDinner.Domain.MenuAggregate.ValueObjects;

namespace CjDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

#pragma warning disable CS8618
    private MenuItem()
    {

    }
#pragma warning restore CS8618

    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }

}