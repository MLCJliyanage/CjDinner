


using CjDinner.Domain.Common.Models;
using CjDinner.Domain.Common.ValueObjects;
using CjDinner.Domain.DinnerAggregate.ValueObjects;
using CjDinner.Domain.HostAggregate.ValueObjects;
using CjDinner.Domain.MenuAggregate.ValueObjects;
using CjDinner.Domain.UserAggregate.ValueObjects;

namespace CjDinner.Domain.HostAggregate;

public class Host : AggregateRoot<HostId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public UserId UserId { get; }
    private readonly List<MenuId> _menuIds = new List<MenuId>();
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    private readonly List<DinnerId> _dinnerIds = new List<DinnerId>();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }

    private Host(
        HostId id,
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
        AverageRating = AverageRating.Create(0);
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = createdDateTime;
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new Host(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow);
    }

    public void UpdateRating(AverageRating newRating)
    {
        AverageRating = newRating;
        UpdatedDateTime = DateTime.UtcNow;
    }

    // ... [Other methods remain the same]
}