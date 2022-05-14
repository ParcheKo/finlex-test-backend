using System;
using Orders.Domain.SeedWork;

namespace Orders.Domain.Persons;

public class PersonRegistered : DomainEventBase
{
    public PersonRegistered(
        Guid personId,
        string email,
        string name
    )
    {
        PersonId = personId;
        Email = email;
        Name = name;
    }

    public Guid PersonId { get; }
    public string Email { get; }
    public string Name { get; }
}