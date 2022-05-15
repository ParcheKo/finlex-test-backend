using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using Orders.Domain.Orders.Events;
using Orders.Domain.Persons;
using Orders.Infrastructure.ReadDatabase.Models;
using Orders.Infrastructure.ReadDatabase.MongoDb;

namespace Orders.Infrastructure.ReadDatabase.EventHandlers;

public class MaterializePersonFlatWhenOrderRegisteredHandler : INotificationHandler<OrderRegisteredEvent>
{
    private readonly ReadDbContext _readDbContext;

    public MaterializePersonFlatWhenOrderRegisteredHandler(ReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }

    public async Task Handle(
        OrderRegisteredEvent notification,
        CancellationToken cancellationToken
    )
    {
        var person = await _readDbContext.PersonFlatMaterializedView
            .Find(p => p.Email == notification.CreatedBy)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        person.OrderCount++;
        person.TotalShopping += notification.TotalPrice;
        person.LastShoppingDate = notification.OrderDate;
        if (notification.TotalPrice > (person.HighestOrderTotalPrice ?? 0))
        {
            person.HighestOrderTotalPrice = notification.TotalPrice;
        }

        await _readDbContext.PersonFlatMaterializedView.ReplaceOneAsync(
            p => p.PersonId == person.PersonId,
            person,
            cancellationToken: cancellationToken
        );
    }
}