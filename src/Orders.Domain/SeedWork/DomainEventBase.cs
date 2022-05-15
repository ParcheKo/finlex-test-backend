using System;

namespace Orders.Domain.SeedWork;

public class DomainEventBase : IDomainEvent
{
    protected DomainEventBase()
    {
        Id = new Guid();
        OccurredOn = DateTime.UtcNow;
    }

    public Guid Id { get; }
    public DateTime OccurredOn { get; }
}