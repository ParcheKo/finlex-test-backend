using System.Collections.Generic;
using Orders.Application.Configuration.Queries;
using Orders.Application.Orders;

namespace Orders.Infrastructure.Query.Orders.GetOrders;

public class GetOrdersQuery : IQuery<List<OrderViewModel>>
{
}