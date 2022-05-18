using Orders.Core;
using Orders.Infrastructure.Emails;

namespace Orders.Infrastructure;

public class AppConfiguration
{
    public DatabaseConfiguration DatabaseConfiguration { get; set; }
    public EmailSettings EmailSettings { get; set; }
}

public class ConnectionStrings
{
    public string SqlServerConnectionString { get; set; }
    public string MongoConnectionString { get; set; }
    public string MongoDatabaseName { get; set; }
}

public class DatabaseConfiguration
{
    public ConnectionStrings ConnectionStrings { get; set; }
    public DatabaseNamingConvention DatabaseNamingConvention { get; set; }
}