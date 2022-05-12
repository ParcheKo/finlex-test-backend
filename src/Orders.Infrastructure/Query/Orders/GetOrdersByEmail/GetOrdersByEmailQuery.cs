using System.Collections.Generic;
using Orders.Application.Configuration.Queries;
using Orders.Application.Orders;

namespace Orders.Infrastructure.Query.Orders.GetOrdersByEmail;

public class GetOrdersByEmailQuery : IQuery<List<OrderViewModel>>
{
    public GetOrdersByEmailQuery(string email)
    {
        Email = email;
    }

    public string Email { get; }
}