

using CjDinner.Domain.Common.Models;
using CjDinner.Domain.Common.ValueObjects;
using CjDinner.Domain.DinnerAggregate.Entities;
using CjDinner.Domain.DinnerAggregate.Enums;
using CjDinner.Domain.DinnerAggregate.ValueObjects;
using CjDinner.Domain.HostAggregate.ValueObjects;
using CjDinner.Domain.MenuAggregate.ValueObjects;

namespace CjDinner.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public DinnerStatus Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Money Price { get; private set; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; private set; }
    public Location Location { get; private set; }
    private readonly List<Reservation> _reservations = new List<Reservation>();
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }


    public Dinner(DinnerId id, string name, string description, DateTime startDateTime, DateTime endDateTime,
           bool isPublic, int maxGuests, Money price, HostId hostId, MenuId menuId, string imageUrl, Location location,
           DateTime createdDateTime)
           : base(id)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = DinnerStatus.Upcoming;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = createdDateTime;
    }
}