using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private GuestRating(
        GuestRatingId guestRatingId,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(guestRatingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        Rating rating
    )
    {
        return new(
            GuestRatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

}