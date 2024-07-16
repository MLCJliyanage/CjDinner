


using CjDinner.Domain.BillAggregate.ValueObjects;
using CjDinner.Domain.Common.Models;
using CjDinner.Domain.DinnerAggregate.ValueObjects;
using CjDinner.Domain.GuestAggregate.ValueObjects;
using CjDinner.Domain.HostAggregate.ValueObjects;

namespace CjDinner.Domain.BillAggregate;

public class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; private set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }

    private Bill(
        BillId id,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdDateTime) : base(id)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = createdDateTime;
    }

    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price)
    {
        return new Bill(
            BillId.CreateUnique(),
            dinnerId,
            guestId,
            hostId,
            price,
            DateTime.UtcNow);
    }

    public void UpdatePrice(Price newPrice)
    {
        Price = newPrice;
        UpdatedDateTime = DateTime.UtcNow;
    }
}