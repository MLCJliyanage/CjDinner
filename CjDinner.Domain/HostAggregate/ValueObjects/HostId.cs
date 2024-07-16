using CjDinner.Domain.Common.Models;

namespace CjDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public string Value { get; }

    private HostId(string value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid().ToString());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static HostId Create(Guid value) => new(value.ToString());

    public static HostId Create(string value)
    {
        return new(value.ToString());
    }
}