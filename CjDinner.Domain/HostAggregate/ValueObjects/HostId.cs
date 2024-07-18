using CjDinner.Domain.Common.Models;

namespace CjDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }

#pragma warning disable CS8618
    private HostId()
    {

    }
#pragma warning restore CS8618

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static HostId Create(Guid value)
    {
        return new HostId(value);
    }

    public static HostId Create(string value)
    {
        return new(Guid.NewGuid());
    }
}