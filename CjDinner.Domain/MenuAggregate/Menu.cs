

using CjDinner.Domain.Common.Models;
using CjDinner.Domain.Common.ValueObjects;
using CjDinner.Domain.DinnerAggregate.ValueObjects;
using CjDinner.Domain.HostAggregate.ValueObjects;
using CjDinner.Domain.MenuAggregate.Entities;
using CjDinner.Domain.MenuAggregate.ValueObjects;
using CjDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace CjDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public HostId HostId { get; private set; }
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }


    public Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        List<MenuSection> sections,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(menuId)
    {
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        HostId = hostId;
        _sections = sections;
        AverageRating = AverageRating.CreateNew();
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        List<MenuSection> sections
    )
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            sections,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

#pragma warning disable CS8618
    private Menu()
    {

    }
#pragma warning restore CS8618
}