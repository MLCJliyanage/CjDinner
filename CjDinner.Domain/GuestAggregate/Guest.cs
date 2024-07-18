

using CjDinner.Domain.BillAggregate.ValueObjects;
using CjDinner.Domain.Common.Models;
using CjDinner.Domain.Common.ValueObjects;
using CjDinner.Domain.DinnerAggregate.ValueObjects;
using CjDinner.Domain.GuestAggregate.ValueObjects;
using CjDinner.Domain.MenuReviewAggregate.ValueObjects;
using CjDinner.Domain.UserAggregate.ValueObjects;

namespace CjDinner.Domain.GuestAggregate;

public class Guest : AggregateRoot<GuestId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public UserId UserId { get; }
    private readonly List<DinnerId> _upcomingDinnerIds = new List<DinnerId>();
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    private readonly List<DinnerId> _pastDinnerIds = new List<DinnerId>();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    private readonly List<DinnerId> _pendingDinnerIds = new List<DinnerId>();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    private readonly List<BillId> _billIds = new List<BillId>();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    private readonly List<MenuReviewId> _menuReviewIds = new List<MenuReviewId>();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    private readonly List<Rating> _ratings = new List<Rating>();
    public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }

    private Guest(
        GuestId id,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        AverageRating = AverageRating.CreateNew();
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = createdDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new Guest(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow);
    }

}