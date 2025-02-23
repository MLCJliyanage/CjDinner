using CjDinner.Domain.Common.Models;

namespace CjDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; }

    private MenuId(Guid value)
    {
        Value = value;
    }

#pragma warning disable CS8618
    private MenuId()
    {

    }
#pragma warning restore CS8618

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}