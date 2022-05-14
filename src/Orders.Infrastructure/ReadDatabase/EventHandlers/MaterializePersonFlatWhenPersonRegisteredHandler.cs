using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Orders.Domain.Persons;
using Orders.Infrastructure.ReadDatabase.Models;
using Orders.Infrastructure.ReadDatabase.MongoDb;

namespace Orders.Infrastructure.ReadDatabase.EventHandlers;

public class MaterializePersonFlatWhenPersonRegisteredHandler : INotificationHandler<PersonRegisteredEvent>
{
    private readonly ReadDbContext _readDbContext;

    public MaterializePersonFlatWhenPersonRegisteredHandler(ReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }

    public async Task Handle(
        PersonRegisteredEvent notification,
        CancellationToken cancellationToken
    )
    {
        var person = new PersonFlatQueryModel()
        {
            Id = Guid.NewGuid(),
            PersonId = notification.PersonId,
            Email = notification.Email,
            Name = notification.Name,
            OrderCount = 1,
            TotalShopping = 0,
            FirstShoppingDate = notification.OccurredOn,
            LastShoppingDate = notification.OccurredOn,
            HighestOrderTotalPrice = null,
        };

        await _readDbContext.PersonFlatMaterializedView.InsertOneAsync(
            person,
            cancellationToken: cancellationToken
        );
    }
}