using CjDinner.Domain.Common.Models;

namespace CjDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

#pragma warning disable CS8618
    private MenuItemId()
    {

    }
#pragma warning restore CS8618

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuItemId Create(Guid value)
    {
        return new MenuItemId(value);
    }
}