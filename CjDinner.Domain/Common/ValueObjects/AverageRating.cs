using CjDinner.Domain.Common.Models;

namespace CjDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    public double Value { get; private set; }
    public int NumRatings { get; private set; }

    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

#pragma warning disable CS8618
    private AverageRating()
    {

    }
#pragma warning restore CS8618

    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
    {

        return new AverageRating(rating, numRatings);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
    }
}