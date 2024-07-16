

using CjDinner.Domain.Common.Models;
using CjDinner.Domain.Common.ValueObjects;
using CjDinner.Domain.DinnerAggregate.ValueObjects;
using CjDinner.Domain.GuestAggregate.ValueObjects;
using CjDinner.Domain.HostAggregate.ValueObjects;

namespace CjDinner.Domain.GuestAggregate.Entities;

public class GuestRating : Entity<RatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; private set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }

    private GuestRating(
        RatingId id,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdDateTime) : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = createdDateTime;
    }

    public static GuestRating Create(HostId hostId, DinnerId dinnerId, Rating rating)
    {
        return new GuestRating(
            RatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            DateTime.UtcNow);
    }

    public void UpdateRating(Rating rating)
    {
        Rating = rating;
        UpdatedDateTime = DateTime.UtcNow;
    }
}