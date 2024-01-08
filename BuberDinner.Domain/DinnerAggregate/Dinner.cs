using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime StartedDateTime { get; }
    public DateTime EndedDateTime { get; }
    public Status Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime startedDateTime,
        DateTime endedDateTime,
        Status status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime startedDateTime,
        DateTime endedDateTime,
        Status status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location
    )
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            startedDateTime,
            endedDateTime,
            status,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

}