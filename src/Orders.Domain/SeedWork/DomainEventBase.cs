using System;

namespace Orders.Domain.SeedWork;

public class DomainEventBase : IDomainEvent
{
    protected DomainEventBase()
    {
        Id = new Guid();
        OccurredOn = DateTime.Now;
    }

    public Guid Id { get; }
    public DateTime OccurredOn { get; }
}