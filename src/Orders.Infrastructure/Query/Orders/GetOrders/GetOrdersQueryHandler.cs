using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using Orders.Application.Configuration.Queries;
using Orders.Application.Orders;
using Orders.Infrastructure.ReadDatabase.Models;
using Orders.Infrastructure.ReadDatabase.MongoDb;

namespace Orders.Infrastructure.Query.Orders.GetOrders;

internal sealed class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, List<OrderViewModel>>
{
    private readonly ReadDbContext _readDbContext;

    public GetOrdersQueryHandler(ReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }

    public async Task<List<OrderViewModel>> Handle(
        GetOrdersQuery request,
        CancellationToken cancellationToken
    )
    {
        var orders = await _readDbContext.OrderFlatMaterializedView
            .Find(Builders<OrderFlatQueryModel>.Filter.Empty)
            .ToListAsync(cancellationToken: cancellationToken);

        return orders.Select(
            p => new OrderViewModel()
            {
                Id = p.OrderId,
                OrderDate = p.OrderDate,
                OrderNo = p.OrderNo,
                CreatedBy = p.CreatedBy,
                ProductName = p.ProductName,
                Total = p.Total,
                Price = p.Price,
                TotalPrice = p.TotalPrice,
            }
        ).ToList();
    }
}