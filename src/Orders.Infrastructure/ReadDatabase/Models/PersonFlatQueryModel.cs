using System;

namespace Orders.Infrastructure.ReadDatabase.Models;

public class PersonFlatQueryModel
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}