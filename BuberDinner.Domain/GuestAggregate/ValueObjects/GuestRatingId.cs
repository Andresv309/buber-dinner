using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

public sealed class GuestRatingId : ValueObject
{
    public Guid Value { get; }

    private GuestRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestRatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static GuestRatingId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}