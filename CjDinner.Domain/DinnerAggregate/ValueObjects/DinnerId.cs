using CjDinner.Domain.Common.Models;

namespace CjDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; private set; }

    private DinnerId(Guid value)
    {
        Value = value;
    }

#pragma warning disable CS8618
    private DinnerId()
    {

    }
#pragma warning restore CS8618

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}