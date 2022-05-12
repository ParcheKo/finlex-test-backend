using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using Orders.Application.Configuration.Queries;
using Orders.Application.Orders;
using Orders.Application.Persons;
using Orders.Infrastructure.ReadDatabase.Models;
using Orders.Infrastructure.ReadDatabase.MongoDb;

namespace Orders.Infrastructure.Query.Persons.GetPersons;

internal sealed class GetPersonsQueryHandler : IQueryHandler<GetPersonsQuery, List<PersonViewModel>>
{
    private readonly ReadDbContext _readDbContext;

    public GetPersonsQueryHandler(ReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }

    public async Task<List<PersonViewModel>> Handle(
        GetPersonsQuery request,
        CancellationToken cancellationToken
    )
    {
        var orders = await _readDbContext.PersonFlatMaterializedView
            .Find(Builders<PersonFlatQueryModel>.Filter.Empty)
            .ToListAsync(cancellationToken: cancellationToken);

        return orders.Select(
            p => new PersonViewModel
            {
                Id = p.PersonId,
                Email = p.Email,
                Name = p.Name,
                OrderCount = p.OrderCount,
                TotalPrice = p.TotalPrice,
                HighestOrderTotalPrice = p.HighestOrderTotalPrice,
                FirstShoppingDate = p.FirstShoppingDate,
                LastShoppingDate = p.LastShoppingDate,
            }
        ).ToList();
    }
}