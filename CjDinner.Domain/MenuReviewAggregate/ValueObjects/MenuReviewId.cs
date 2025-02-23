using CjDinner.Domain.Common.Models;

namespace CjDinner.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    public Guid Value { get; }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

#pragma warning disable CS8618
    private MenuReviewId()
    {

    }
#pragma warning restore CS8618

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}