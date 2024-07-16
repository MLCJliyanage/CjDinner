
using CjDinner.Domain.BillAggregate.ValueObjects;
using CjDinner.Domain.Common.Models;
using CjDinner.Domain.DinnerAggregate.Enums;
using CjDinner.Domain.DinnerAggregate.ValueObjects;
using CjDinner.Domain.GuestAggregate.ValueObjects;

namespace CjDinner.Domain.DinnerAggregate.Entities;

public class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; private set; }
    public ReservationStatus Status { get; private set; }
    public GuestId GuestId { get; }
    public BillId? BillId { get; private set; }
    public DateTime? ArrivalDateTime { get; private set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }

    private Reservation(
        ReservationId id,
        GuestId guestId,
        int guestCount,
        DateTime createdDateTime) : base(id)
    {
        GuestId = guestId;
        GuestCount = guestCount;
        Status = ReservationStatus.PendingGuestConfirmation;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = createdDateTime;
    }

    public static Reservation Create(GuestId guestId, int guestCount)
    {
        return new Reservation(
            ReservationId.CreateUnique(),
            guestId,
            guestCount,
            DateTime.UtcNow);
    }

    public void Confirm()
    {
        Status = ReservationStatus.Reserved;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void Cancel()
    {
        Status = ReservationStatus.Cancelled;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AssignBill(BillId billId)
    {
        BillId = billId;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void RecordArrival(DateTime arrivalTime)
    {
        ArrivalDateTime = arrivalTime;
        UpdatedDateTime = DateTime.UtcNow;
    }
}