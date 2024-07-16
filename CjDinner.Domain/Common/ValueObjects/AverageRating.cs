using CjDinner.Domain.Common.Models;

namespace CjDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    public float Value { get; }

    private AverageRating(float value)
    {
        Value = value;
    }

    public static AverageRating Create(float value)
    {
        if (value < 0 || value > 5)
            throw new ArgumentOutOfRangeException(nameof(value), "Average rating must be between 0 and 5.");

        return new AverageRating(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
    }
}